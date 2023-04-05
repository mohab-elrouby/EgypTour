using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CommentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public GenericResponse<List<CommentDTO>> Index()
        {
            try
            {
                var comments = _unitOfWork.Comment.GetAll().ToList();

                if (comments.Count == 0)
                {
                    return new GenericResponse<List<CommentDTO>>()
                    {
                        StatusCode = 404,
                        Message = "There are no comments to display",

                    };
                }
                else
                {
                    var commentDto = _mapper.Map<List<CommentDTO>>(comments);
                    return new GenericResponse<List<CommentDTO>>()
                    {
                        StatusCode = 200,
                        Message = "Get Comment Done",
                        Data = commentDto

                    };
                }
            }
            catch
            {
                return new GenericResponse<List<CommentDTO>>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }
        [HttpGet]
        [Route("GetByPostId")]
        public GenericResponse<List<CommentDTO>> GetByPostId([FromQuery] int postId)
        {
            try
            {
                var comments = _unitOfWork.Comment.GetByPostsId(postId).ToList();

                if (comments.Count == 0)
                {
                    return new GenericResponse<List<CommentDTO>>()
                    {
                        StatusCode = 404,
                        Message = "There are no comments to display",

                    };
                }
                else
                {
                    var commentDto = _mapper.Map<List<CommentDTO>>(comments);
                    return new GenericResponse<List<CommentDTO>>()
                    {
                        StatusCode = 200,
                        Message = "Get Comment Done",
                        Data = commentDto

                    };
                }
            }
            catch
            {
                return new GenericResponse<List<CommentDTO>>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }

        [HttpPost]
        public GenericResponse<CommentDTO> Add([FromBody] CommentDTO commentDTO)
        {
            try
            {
                if (commentDTO == null)
                {
                    return new GenericResponse<CommentDTO>()
                    {
                        StatusCode = 404,
                        Message = "Enter Your Data",

                    };
                }
                else
                {
                    var comment = _mapper.Map<Comment>(commentDTO);

                    _unitOfWork.Comment.Add(comment);
                    _unitOfWork.Commit();
                    return new GenericResponse<CommentDTO>()
                    {
                        StatusCode = 200,
                        Message = "The comment has been added successfully",
                        Data = commentDTO

                    };
                }
            }
            catch
            {
                return new GenericResponse<CommentDTO>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }

        [HttpPut]
        public GenericResponse<CommentDTO> Update([FromQuery] int id, [FromBody] CommentDTO commentDTO)
        {
            try
            {
                if (commentDTO == null)
                {
                    return new GenericResponse<CommentDTO>()
                    {
                        StatusCode = 404,
                        Message = "Enter Your Data",

                    };
                }
                else
                {
                    var comment = _mapper.Map<Comment>(commentDTO);
                    comment.Id=id;
                    _unitOfWork.Comment.Update(comment);
                    _unitOfWork.Commit();
                    return new GenericResponse<CommentDTO>()
                    {
                        StatusCode = 200,
                        Message = "The comment has been updated successfully",
                        Data = commentDTO

                    };
                }
            }
            catch
            {
                return new GenericResponse<CommentDTO>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }

        }

    }
}
