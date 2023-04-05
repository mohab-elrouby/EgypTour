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

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ActivityController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetByTripId")]
        public GenericResponse<List<ActivityDTO>> GetByTripId([FromQuery] int TripId)
        {
            try
            {
                var activities = _unitOfWork.Activity.GetByTripId(TripId).ToList();

                if (activities.Count == 0)
                {
                    return new GenericResponse<List<ActivityDTO>>()
                    {
                        StatusCode = 404,
                        Message = "No Data",

                    };
                }
                else
                {
                    var activityDto = _mapper.Map<List<ActivityDTO>>(activities);
                    return new GenericResponse<List<ActivityDTO>>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull",
                        Data = activityDto

                    };
                }
            }
            catch
            {
                return new GenericResponse<List<ActivityDTO>>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }

        [HttpPost]
        public GenericResponse<ActivityDTO> Add([FromBody] ActivityDTO activityDTO)
        {
            try
            {

                Activity activity = _unitOfWork.Activity.GetById(activityDTO.Id);
                
                if (activity!=null)
                {
                    ActivityDTO activityDTO1 = _mapper.Map<ActivityDTO>(activity);
                    return new GenericResponse<ActivityDTO>()
                    {
                        StatusCode = 403,
                        Message = "Activity already exists",
                        Data = activityDTO1
                    };
                }
                Activity activity1 = new Activity( name: activityDTO.Name
                    , description: activityDTO.Description, tag: activityDTO.Tag
                    , documents: activityDTO.Documents, start: activityDTO.Start,
                    end: activityDTO.End, tripId: activityDTO.TripId, notes: activityDTO.Notes,
                    location: activityDTO.Location);
                _unitOfWork.Activity.Add(activity1);
                _unitOfWork.Commit();
                return new GenericResponse<ActivityDTO>()
                {
                    StatusCode = 200,
                    Message = "Activity added Sucessfully"
                };

            }
            catch
            {
                return new GenericResponse<ActivityDTO>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }


        [HttpPut]
    public GenericResponse<ActivityDTO> Update([FromQuery] int id, [FromBody] ActivityDTO activityDTO)
    {
        try
        {
            if (activityDTO == null)
            {
                return new GenericResponse<ActivityDTO>()
                {
                    StatusCode = 404,
                    Message = "Enter Your Data",

                };
            }
            else
            {
                var activity = _mapper.Map<Activity>(activityDTO);
                _unitOfWork.Activity.Update(activity);
                _unitOfWork.Commit();
                return new GenericResponse<ActivityDTO>()
                {
                    StatusCode = 200,
                    Message = "The Process of Updated Data Sucessfull",
                    Data = activityDTO

                };
            }
        }
        catch
        {
            return new GenericResponse<ActivityDTO>()
            {
                StatusCode = 500,
                Message = "Internal Error",

            };
        }

    }

    [HttpDelete]
    public GenericResponse<ActivityDTO> Delete(int id)
    {
        Activity activity = _unitOfWork.Activity.GetById(id);
        try
        {
            if (activity == null)
            {
                return new GenericResponse<ActivityDTO>()
                {
                    StatusCode = 404,
                    Message = "No Reviews Found",

                };
            }
            else
            {
                _unitOfWork.Activity.Delete(id);
                _unitOfWork.Commit();
                return new GenericResponse<ActivityDTO>()
                {
                    StatusCode = 200,
                    Message = "The Process of Get Data Sucessfull"

                };
            }
        }


        catch
        {
            return new GenericResponse<ActivityDTO>()
            {
                StatusCode = 500,
                Message = "Internal Error",

            };
        }
    }
}

}
