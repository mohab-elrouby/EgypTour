using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Services;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TouristController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAuthenticationService _authenticationService;

        public TouristController(IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
        {
            this.unitOfWork=unitOfWork;
            _authenticationService=authenticationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var allTourists = unitOfWork._tourists.GetAll().ToList();
                if (allTourists != null)
                {
                    return Ok(allTourists);
                }
                return BadRequest("No");
            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 500, ex.StackTrace);
            }

        }
        [HttpGet("{id}", Name = "GetByTouristId")]
        public IActionResult GetById(int id)
        {
            try
            {
                var user = unitOfWork._tourists.GetById(id);
                if (user != null)
                {
                    return Ok(user);
                }
                return BadRequest($"No user with id:{id}");
            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 500, ex.StackTrace);
            }

        }

        [HttpPost("add")]
        public IActionResult Add(UserDTO userDTO)
        {
            if(userDTO == null)
            {
                return Ok();
            }
            var newUser = UserDTO.ToTourist(userDTO);
            _authenticationService.CreatePasswordHash(newUser.Password, out byte[] passwordHash, out byte[] passwordSalt);
            newUser.EncryptPassword(passwordHash, passwordSalt);
            try
            {
                unitOfWork._tourists.Add(newUser);
                unitOfWork.Commit();
                string url = Url.Link("GetByTouristId", new { id = newUser.Id });
                return Created(url, newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 500, ex.StackTrace);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var token = _authenticationService.Login(loginDTO.Username, loginDTO.Password);
            if (token == string.Empty)
            {
                return Ok(new { Token = token, Status = "Wrong Credientials" });
            }
            return Ok(new {Token = token, Status = "Successful Login" });
        }

        [HttpGet("GetFriends")]
        public IActionResult GetFriends(int userId, int skip = 0, int take = 8)
        {
            try
            {
                var freinds = unitOfWork.TouristFriends.Find(f => f.TouristId == userId, skip: skip, take: take, includeProperties: "Friend");
                // this works right now because if we add user2 to the friends list of user1 it's saved as follows
                // 1, 2; and if you save user1 to user2 friends list in another context, it will also be saved
                // 2, 1; this is called "Asymmetric" many to many relationship. if in the futere we use "Symmetric"
                // relationship this query needs to check if the id exists in either columns.
                if (freinds == null)
                {
                    return NotFound();
                }
                return Ok(freinds.Select(f => new {f.Friend.Id, f.Friend.Fname, f.Friend.Lname, f.Friend.ProfilePictureUrl}));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

        [HttpPatch("addFriend")]
        public IActionResult AddFriend(int userId, int friendId)
        {
            try
            {
                var user = unitOfWork._tourists.GetById(userId);
                var friend = unitOfWork._tourists.GetById(friendId);
                if (user == null || friend == null)
                {
                    return NotFound();
                }
                unitOfWork.TouristFriends.Add(new TouristFriend(userId, friendId));
                unitOfWork.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

        [HttpPatch("removeFriend")]
        public IActionResult RemoveFriend(int userId, int friendId)
        {
            try
            {
                var user = unitOfWork._tourists.GetById(userId);
                var touristFriend = unitOfWork.TouristFriends.Find(tf => (tf.TouristId == userId && tf.FriendId == friendId));
                if (touristFriend == null)
                {
                    return NotFound();
                }
                user.DeleteFriend(touristFriend.FirstOrDefault());
                unitOfWork._tourists.Update(user);
                unitOfWork.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

        [Route("{Id}/AddImage")]
        [HttpPost]
        public IActionResult AddImage([FromForm] IFormFile file, int touristId)
        {
            try
            {
                var tourist = unitOfWork._tourists.GetById(touristId);
                if (tourist == null)
                {
                    return NotFound("User doesn't exist");
                }
                string uniqueName = WriteDeleteFileService.Write(file, "wwwroot/user-images/");
                string imageUrl = $"/user-images/{uniqueName}";
                tourist.UploadImage(imageUrl);
                unitOfWork.Commit();
                return Ok("image uploaded successfually");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

        [HttpPut]
        public IActionResult Update(UserDTO userDTO)
        {
            try
            {
                var user = unitOfWork._tourists.GetById(userDTO.Id);
                if(user == null)
                {
                    return NotFound();
                }
                user.UpdateInfo(userDTO);
                unitOfWork._tourists.Update(user);
                unitOfWork.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }
    }
}
