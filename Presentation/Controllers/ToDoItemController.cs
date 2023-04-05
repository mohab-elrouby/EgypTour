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
    public class ToDoItemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ToDoItemController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetByToDoListId")]
        public GenericResponse<List<ToDoItemDTO>> GetByToDoListId([FromQuery] int ToDoListId)
        {
            try
            {
                var toDos = _unitOfWork.ToDoItem.GetByToDoListId(ToDoListId).ToList();

                if (toDos.Count == 0)
                {
                    return new GenericResponse<List<ToDoItemDTO>>()
                    {
                        StatusCode = 404,
                        Message = "No Data",

                    };
                }
                else
                {
                    var toDoItemDTOs = _mapper.Map<List<ToDoItemDTO>>(toDos);
                    return new GenericResponse<List<ToDoItemDTO>>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull",
                        Data = toDoItemDTOs

                    };
                }
            }
            catch
            {
                return new GenericResponse<List<ToDoItemDTO>>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }
        [HttpPost]
        public GenericResponse<ToDoItemDTO> Add([FromBody] ToDoItemDTO toDoItemDTO)
        {
            
                ToDoItem toDoItem = _unitOfWork.ToDoItem.GetById(toDoItemDTO.Id);

                if (toDoItem!=null)
                {
                    ToDoItemDTO toDoItemDT = _mapper.Map<ToDoItemDTO>(toDoItem);
                    return new GenericResponse<ToDoItemDTO>()
                    {
                        StatusCode = 403,
                        Message = "this Item already exists",
                        Data = toDoItemDT
                    };
                }
                ToDoItem toDo = new ToDoItem(name:toDoItemDTO.Name);
                _unitOfWork.ToDoItem.Add(toDo);
                _unitOfWork.Commit();
                return new GenericResponse<ToDoItemDTO>()
                {
                    StatusCode = 200,
                    Message = "Item added Sucessfully"
                };

            
          
                return new GenericResponse<ToDoItemDTO>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            
        }

        //[HttpPost]
        //public GenericResponse<ToDoItemDTO> Add([FromBody] ToDoItemDTO toDoItemDTO)
        //{
        //    try
        //    {
        //        if (toDoItemDTO == null)
        //        {
        //            return new GenericResponse<ToDoItemDTO>()
        //            {
        //                StatusCode = 404,
        //                Message = "Enter Your Data",

        //            };
        //        }
        //        else
        //        {
        //            var toDo = _mapper.Map<ToDoItem>(toDoItemDTO);

        //            _unitOfWork.ToDoItem.Add(toDo);
        //            _unitOfWork.Commit();
        //            return new GenericResponse<ToDoItemDTO>()
        //            {
        //                StatusCode = 200,
        //                Message = "The Process of Add  Data Sucessfull",
        //                Data = toDoItemDTO

        //            };
        //        }
        //    }
        //    catch
        //    {
        //        return new GenericResponse<ToDoItemDTO>()
        //        {
        //            StatusCode = 500,
        //            Message = "Internal Error",

        //        };
        //    }
        //}

        [HttpPut]
        public GenericResponse<ToDoItemDTO> Update([FromQuery] int id, [FromBody] ToDoItemDTO toDoItemDTO)
        {
            try
            {
                if (toDoItemDTO == null)
                {
                    return new GenericResponse<ToDoItemDTO>()
                    {
                        StatusCode = 404,
                        Message = "Enter Your Data",

                    };
                }
                else
                {
                    var toDo = _mapper.Map<ToDoItem>(toDoItemDTO);
                    _unitOfWork.ToDoItem.Update(toDo);
                    _unitOfWork.Commit();
                    return new GenericResponse<ToDoItemDTO>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Updated Data Sucessfull",
                        Data = toDoItemDTO

                    };
                }
            }
            catch
            {
                return new GenericResponse<ToDoItemDTO>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }

        }
        [HttpDelete]
        public GenericResponse<ToDoItemDTO> Delete(int id)
        {
            ToDoItem toDo = _unitOfWork.ToDoItem.GetById(id);
            try
            {
                if (toDo == null)
                {
                    return new GenericResponse<ToDoItemDTO>()
                    {
                        StatusCode = 404,
                        Message = "No Reviews Found",

                    };
                }
                else
                {
                    _unitOfWork.ToDoItem.Delete(id);
                    _unitOfWork.Commit();
                    return new GenericResponse<ToDoItemDTO>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull"

                    };
                }
            }


            catch
            {
                return new GenericResponse<ToDoItemDTO>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }
    }

}
