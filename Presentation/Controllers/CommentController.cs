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
                        Message = "No Data",

                    };
                }
                else
                {
                    var commentDto = _mapper.Map<List<CommentDTO>>(comments);
                    return new GenericResponse<List<CommentDTO>>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull",
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
        public GenericResponse<List<CommentDTO>> GetByPostId([FromQuery]int postId)
        {
            try
            {
                var comments = _unitOfWork.Comment.GetByPostsId(postId).ToList();

                if (comments.Count == 0)
                {
                    return new GenericResponse<List<CommentDTO>>()
                    {
                        StatusCode = 404,
                        Message = "No Data",

                    };
                }
                else
                {
                    var commentDto = _mapper.Map<List<CommentDTO>>(comments);
                    return new GenericResponse<List<CommentDTO>>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull",
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
                        Message = "The Process of Add  Data Sucessfull",
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
                    //   var commentGetOne = _unitOfWork.Comment.GetById(id);
                    var comment = _mapper.Map<Comment>(commentDTO);
                   
                    _unitOfWork.Comment.Update(comment);
                    _unitOfWork.Commit();
                    return new GenericResponse<CommentDTO>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Updated Data Sucessfull",
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
