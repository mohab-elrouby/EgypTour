using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService PostService;
        private readonly IUnitOfWork unitOfWork;

        public PostController(IPostService postService, IUnitOfWork unitOfWork)
        {
            PostService=postService;
            this.unitOfWork=unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try {
                return Ok(unitOfWork.Posts.GetAll().Select(p => PostDTO.FromEntity(p)));
            } catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }


        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult GetById()
        {
            try
            {
                return Ok(unitOfWork.Posts.GetAll().Select(p => PostDTO.FromEntity(p)));
            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 500, ex.StackTrace);
            }
        }


        [HttpPost]
        public IActionResult Add(PostDTO postDTO)
        {
            if (postDTO != null)
            {
                var post = PostDTO.ToEntity(postDTO);
                try
                {
                    unitOfWork.Posts.Add(post);
                    unitOfWork.Commit();
                    string url = Url.Link("GetById", new { id = post.Id });
                    return Created(url, post);
                } catch (Exception ex)
                {
                    return StatusCode(statusCode: 500, ex.StackTrace);
                }
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                unitOfWork.Posts.Delete(id);
                unitOfWork.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 500, ex.StackTrace);
            }
        }

        [HttpGet("{userId:int}/friends", Name = "GetforFriends")]
        public IActionResult GetForFriends(int id)
        {
            try
            {
                return Ok(PostService.GetForFriends(id).Select(p => PostDTO.FromEntity(p)));
            } catch (Exception ex)
            {
                return StatusCode(statusCode: 500, ex.StackTrace);
            }
        }

        [HttpGet("users/{userId:int}", Name = "GetforUser")]
        public IActionResult GetForUser(int id)
        {
            try
            {
                return Ok(unitOfWork.Posts.Find(p => p.WriterId == id));
            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 500, ex.StackTrace);
            }
        }

        [HttpPost("{PostId:int}/like", Name ="LikePost")]
        public IActionResult Like(int PostId, [FromBody] int likerId)
        {
            try
            {
                var post = unitOfWork.Posts.GetById(PostId); 
                var liker = unitOfWork.Tourists.GetById(likerId);
                if (post!=null && liker !=null)
                {
                    post.AddLiker(liker);
                    unitOfWork.Posts.Update(post);
                    unitOfWork.Commit();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }catch(Exception ex)
            {
                return StatusCode(statusCode: 500, ex.StackTrace);
            }
        }

        [HttpPost("{PostId:int}/comment", Name = "CommentPost")]
        public IActionResult Comment(int PostId, CommentDTO comment)
        {
            try
            {
                var post = unitOfWork.Posts.GetById(PostId);
                if (post!=null)
                {
                    var cmnt = CommentDTO.ToEntity(comment);
                    post.AddComment(cmnt);
                    unitOfWork.Posts.Update(post);
                    unitOfWork.Commit();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 500, ex.StackTrace);
            }
        }

    }
}
