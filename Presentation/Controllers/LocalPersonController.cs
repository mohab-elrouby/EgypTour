using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
                        Message = "There are no results to display",

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
                        Message = "There are no results to display",

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
                        Message = "There are no results to display",

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
                        Message = "There are no results to display",

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
                    LocalPerson person =_unitOfWork.LocalPerson
                    .Find(I=>I.Email==localPersonDTO.Email||
                    I.UsernameName==localPersonDTO.UsernameName).FirstOrDefault();
                if(person!=null)
                {
                    LocalPersonDTO personDTO= _mapper.Map<LocalPersonDTO>(person);
                    return new GenericResponse<LocalPersonDTO>()
                    {
                        StatusCode = 403,
                        Message = "Local person already exists",
                        Data = personDTO
                    };
                }
                LocalPerson localPerson = new LocalPerson(fname:localPersonDTO.Fname,
                   lname:localPersonDTO.Lname,email:localPersonDTO.Email,password:localPersonDTO.Password
                   ,city:localPersonDTO.City,profilePictureUrl:localPersonDTO.ProfilePictureUrl,phone:localPersonDTO.Phone,usernameName:localPersonDTO.UsernameName);
                    _unitOfWork.LocalPerson.Add(localPerson);
                    _unitOfWork.Commit();
                    return new GenericResponse<LocalPersonDTO>()
                    {
                        StatusCode = 200,
                        Message = "Local person added Sucessfully"
                    };
                
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
                    person.Id= id;
                    _unitOfWork.LocalPerson.Update(person);
                    _unitOfWork.Commit();
                    return new GenericResponse<LocalPersonDTO>()
                    {
                        StatusCode = 200,
                        Message = "Data of Local Person has been updated successfully",
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
                        Message = "Not Found",

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

    
