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
    public class LocalPersonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LocalPersonController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public GenericResponse<List<LocalPersonDTO>> Index()
        {
            try
            {
                var person = _unitOfWork.LocalPerson.GetAll().ToList();

                if (person.Count == 0|| person==null)
                {
                    return new GenericResponse<List<LocalPersonDTO>>()
                    {
                        StatusCode = 404,
                        Message = "No Data",

                    };
                }
                else
                {
                    var personDto = _mapper.Map<List<LocalPersonDTO>>(person);
                    return new GenericResponse<List<LocalPersonDTO>>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull",
                        Data = personDto

                    };
                }
            }
            catch
            {
                return new GenericResponse<List<LocalPersonDTO>>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }

        [HttpGet]
        [Route("GetByPersonId")]
        public GenericResponse<List<LocalPersonDTO>> GetByPersonId([FromQuery] int Id)
        {
            try
            {
                var person = _unitOfWork.LocalPerson.GetByPersonId(Id).ToList();

                if (person.Count == 0|| person==null)
                {
                    return new GenericResponse<List<LocalPersonDTO>>()
                    {
                        StatusCode = 404,
                        Message = "No Data",

                    };
                }
                else
                {
                    var personDto = _mapper.Map<List<LocalPersonDTO>>(person);
                    return new GenericResponse<List<LocalPersonDTO>>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull",
                        Data = personDto

                    };
                }
            }
            catch
            {
                return new GenericResponse<List<LocalPersonDTO>>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }

        [HttpGet("{name:alpha}")]
        public GenericResponse<List<LocalPersonDTO>> SearchByName([FromQuery] string name)
        {
            try
            {
                var person = _unitOfWork.LocalPerson.SearchByName(name).ToList();

                if (person.Count == 0)
                {
                    return new GenericResponse<List<LocalPersonDTO>>()
                    {
                        StatusCode = 404,
                        Message = "No Data",

                    };
                }
                else
                {
                    var personDto = _mapper.Map<List<LocalPersonDTO>>(person);
                    return new GenericResponse<List<LocalPersonDTO>>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull",
                        Data = personDto

                    };
                }
            }
            catch
            {
                return new GenericResponse<List<LocalPersonDTO>>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }

        [HttpGet]
        [Route("SearchByLocation")]
        public GenericResponse<List<LocalPersonDTO>> SearchByLocation([FromQuery] string location)
        {
            try
            {
                var person = _unitOfWork.LocalPerson.SearchByLocation(location).ToList();

                if (person.Count == 0)
                {
                    return new GenericResponse<List<LocalPersonDTO>>()
                    {
                        StatusCode = 404,
                        Message = "No Data",

                    };
                }
                else
                {
                    var personDto = _mapper.Map<List<LocalPersonDTO>>(person);
                    return new GenericResponse<List<LocalPersonDTO>>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull",
                        Data = personDto

                    };
                }
            }
            catch
            {
                return new GenericResponse<List<LocalPersonDTO>>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }


        [HttpPost]
        public GenericResponse<LocalPersonDTO> Add([FromBody] LocalPersonDTO localPersonDTO)
        {
            try
            {
                if (localPersonDTO == null)
                {
                    return new GenericResponse<LocalPersonDTO>()
                    {
                        StatusCode = 404,
                        Message = "Enter Your Data",

                    };
                }
                else
                {
                    var person = _mapper.Map<LocalPerson>(localPersonDTO);
                    _unitOfWork.LocalPerson.Add(person);
                    _unitOfWork.Commit();
                    return new GenericResponse<LocalPersonDTO>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Add  Data Sucessfull",
                        Data = localPersonDTO

                    };
                }
            }
            catch
            {
                return new GenericResponse<LocalPersonDTO>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }

        [HttpPut]
        public GenericResponse<LocalPersonDTO> Update([FromQuery] int id, [FromBody] LocalPersonDTO localPersonDTO)
        {
            try
            {
                if (localPersonDTO == null)
                {
                    return new GenericResponse<LocalPersonDTO>()
                    {
                        StatusCode = 404,
                        Message = "Enter Your Data",

                    };
                }
                else
                {
                    var person = _mapper.Map<LocalPerson>(localPersonDTO);
                    _unitOfWork.LocalPerson.Update(person);
                    _unitOfWork.Commit();
                    return new GenericResponse<LocalPersonDTO>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Updated Data Sucessfull",
                        Data = localPersonDTO

                    };
                }
            }
            catch
            {
                return new GenericResponse<LocalPersonDTO>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }

        }

        [HttpDelete]
        public GenericResponse<LocalPersonDTO> DeletePerson(int id)
        {
            LocalPerson localPerson = _unitOfWork.LocalPerson.GetById(id);
            try
            {
                if (localPerson == null)
                {
                    return new GenericResponse<LocalPersonDTO>()
                    {
                        StatusCode = 404,
                        Message = "No Reviews Found",

                    };
                }
                else
                {
                    _unitOfWork.LocalPerson.Delete(id);
                    _unitOfWork.Commit();
                    return new GenericResponse<LocalPersonDTO>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull"

                    };
                }
            }


            catch
            {
                return new GenericResponse<LocalPersonDTO>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }
    }
}

    
