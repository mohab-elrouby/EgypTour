using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Services;
using System;

namespace Presentation.Controllers
{
    [Route("[controller]")]
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
        public IActionResult Get(int skip = 0, int take = 8)
        {
            try 
            {
                List<PostDTO> allPosts = unitOfWork.Posts.Find(p => true, skip: skip, take: take, includeProperties: "Writer,Comments.Writer,Likers", orderBy: i => i.OrderByDescending(x =>  x.DatePosted)).Select(p => PostDTO.FromEntity(p)).ToList();
                if(allPosts == null)
                {
                    return NotFound();
                }
                return Ok(allPosts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }


        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                Post post = unitOfWork.Posts.Find(p=>p.Id == id, includeProperties: "Writer").FirstOrDefault();
                if(post == null)
                {
                    return NotFound();
                }
                return Ok(PostDTO.FromEntity(post));
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
        public IActionResult GetForFriends(int id, int skip = 0, int take = 8)
        {
            try
            {
                var friendsPosts = PostService.GetForFriends(id, skip: skip, take: take).Select(p => PostDTO.FromEntity(p));
                if(friendsPosts == null)
                {
                    return NotFound();
                }
                return Ok(friendsPosts.ToList());
            } catch (Exception ex)
            {
                return StatusCode(statusCode: 500, ex.StackTrace);
            }
        }

        [HttpGet("users/{userId:int}", Name = "GetforUser")]
        public IActionResult GetForUser(int id, int skip = 0, int take = 8)
        {
            try
            {
                var posts = unitOfWork.Posts.Find(p => p.WriterId == id, skip: skip, take:skip, includeProperties: "Writer").Select(p => PostDTO.FromEntity(p));
                if(posts == null)
                {
                    return BadRequest();
                }
                return Ok(posts.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(statusCode: 500, ex.StackTrace);
            }
        }

        [HttpPatch("{PostId:int}/like", Name ="LikePost")]
        public IActionResult Like(int PostId, [FromBody] int likerId)
        {
            try
            {

                var post = unitOfWork.Posts.Find(predicate: x => x.Id == PostId, includeProperties: "Likers").FirstOrDefault();
                var liker = unitOfWork._tourists.GetById(likerId);
                if ((post!=null && liker !=null)  )
                {
                    if (!post.hasLike(likerId))
                    {
                        post.AddLiker(liker);

                        unitOfWork.Posts.Update(post);
                        unitOfWork.Commit();
                        return Ok();
                    }
                    post.RemoveLiker(liker);
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

        [HttpPatch("{PostId:int}/unlike", Name = "UnLikePost")]
        public IActionResult UnLike(int PostId, [FromBody] int likerId)
        {
            try
            {
                var post = unitOfWork.Posts.GetById(PostId);
                var liker = unitOfWork._tourists.GetById(likerId);
                if (post!=null && liker !=null)
                {
                    post.RemoveLiker(liker);
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

        [HttpPatch("{PostId:int}/comment", Name = "CommentPost")]
        public IActionResult Comment(int PostId, CommentDTO comment)
        {
            Console.WriteLine(comment);
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

        [HttpDelete("{PostId:int}/uncomment", Name = "UnCommentPost")]
        public IActionResult UnComment(int PostId, int commentId)
        {
            try
            {
                var post = unitOfWork.Posts.Find(predicate:x=>x.Id == PostId,includeProperties:"Comments").FirstOrDefault();
                if (post!=null)
                {
                    //var cmnt = CommentDTO.ToEntity(comment);
                    post.RemoveComment(commentId);
                    //unitOfWork.Posts.Update(post);
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

        [Route("{PostId}/AddImage")]
        [HttpPost]
        public IActionResult AddPostImage([FromForm] IFormFile file, int postId)
        {
            try
            {
                Post post = unitOfWork.Posts.GetById(postId);
                if (post == null)
                {
                    return NotFound("Post doesn't exist");
                }
                string uniqueName = WriteDeleteFileService.Write(file, "wwwroot/post-images/");
                string imageUrl = $"/post-images/{uniqueName}";
                post.AddImage(imageUrl);
                unitOfWork.Commit();
                return Ok(imageUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

    }

}
