using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MessageController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetBySenderId")]
        public GenericResponse<List<MessageDTO>> GetBySenderId([FromQuery] int SenderId)
        {
            try
            {
                var messeges = _unitOfWork.Message.GetBySenderId(SenderId).ToList();

                if (messeges.Count == 0)
                {
                    return new GenericResponse<List<MessageDTO>>()
                    {
                        StatusCode = 404,
                        Message = "No Data",

                    };
                }
                else
                {
                    var messageDto = _mapper.Map<List<MessageDTO>>(messeges);
                    return new GenericResponse<List<MessageDTO>>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull",
                        Data = messageDto

                    };
                }
            }
            catch
            {
                return new GenericResponse<List<MessageDTO>>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }
    
        [HttpGet]
        [Route("GetByReceiverId")]
        public GenericResponse<List<MessageDTO>> GetByReceiverId([FromQuery] int ReceiverId)
        {
            try
            {
                var messeges = _unitOfWork.Message.GetByReceiverId(ReceiverId).ToList();

                if (messeges.Count == 0)
                {
                    return new GenericResponse<List<MessageDTO>>()
                    {
                        StatusCode = 404,
                        Message = "No Data",

                    };
                }
                else
                {
                    var messageDto = _mapper.Map<List<MessageDTO>>(messeges);
                    return new GenericResponse<List<MessageDTO>>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull",
                        Data = messageDto

                    };
                }
            }
            catch
            {
                return new GenericResponse<List<MessageDTO>>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }

        [HttpPost]
        public GenericResponse<MessageDTO> Add([FromBody] MessageDTO messageDTO)
        {
            try
            {
                if (messageDTO == null)
                {
                    return new GenericResponse<MessageDTO>()
                    {
                        StatusCode = 404,
                        Message = "Enter Your Data",

                    };
                }
                else
                {
                    var message = _mapper.Map<Messege>(messageDTO);

                    _unitOfWork.Message.Add(message);
                    _unitOfWork.Commit();
                    return new GenericResponse<MessageDTO>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Add  Data Sucessfull",
                        Data = messageDTO

                    };
                }
            }
            catch
            {
                return new GenericResponse<MessageDTO>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }


        [HttpPut]
        public GenericResponse<MessageDTO> Update([FromQuery] int id, [FromBody] MessageDTO messageDTO)
        {
            try
            {
                if (messageDTO == null)
                {
                    return new GenericResponse<MessageDTO>()
                    {
                        StatusCode = 404,
                        Message = "Enter Your Data",

                    };
                }
                else
                {
                    var messege = _mapper.Map<Messege>(messageDTO);
                    _unitOfWork.Message.Update(messege);
                    _unitOfWork.Commit();
                    return new GenericResponse<MessageDTO>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Updated Data Sucessfull",
                        Data = messageDTO

                    };
                }
            }
            catch
            {
                return new GenericResponse<MessageDTO>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }

        }
        [HttpDelete]
        public GenericResponse<MessageDTO> Delete(int id)
        {
            Messege messege = _unitOfWork.Message.GetById(id);
            try
            {
                if (messege == null)
                {
                    return new GenericResponse<MessageDTO>()
                    {
                        StatusCode = 404,
                        Message = "No Reviews Found",

                    };
                }
                else
                {
                    _unitOfWork.Message.Delete(id);
                    _unitOfWork.Commit();
                    return new GenericResponse<MessageDTO>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull"

                    };
                }
            }


            catch
            {
                return new GenericResponse<MessageDTO>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }
    }

}
