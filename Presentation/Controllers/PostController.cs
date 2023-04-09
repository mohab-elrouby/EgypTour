﻿using Domain.DTOs;
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
            try 
            {
                var allPosts = unitOfWork.Posts.GetAll().Select(p => PostDTO.FromEntity(p));
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
                var post = unitOfWork.Posts.GetById(id);
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
        public IActionResult GetForFriends(int id)
        {
            try
            {
                var friendsPosts = PostService.GetForFriends(id).Select(p => PostDTO.FromEntity(p));
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
        public IActionResult GetForUser(int id)
        {
            try
            {
                var posts = unitOfWork.Posts.Find(p => p.WriterId == id);
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

        [HttpPatch("{PostId:int}/unlike", Name = "UnLikePost")]
        public IActionResult UnLike(int PostId, [FromBody] int likerId)
        {
            try
            {
                var post = unitOfWork.Posts.GetById(PostId);
                var liker = unitOfWork.Tourists.GetById(likerId);
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

        [HttpPatch("{PostId:int}/uncomment", Name = "UnCommentPost")]
        public IActionResult UnComment(int PostId, CommentDTO comment)
        {
            try
            {
                var post = unitOfWork.Posts.GetById(PostId);
                if (post!=null)
                {
                    var cmnt = CommentDTO.ToEntity(comment);
                    post.RemoveComment(cmnt);
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
