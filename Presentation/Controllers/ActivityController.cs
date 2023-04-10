using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
      
        private readonly IUnitOfWork _unitOfWork;
        public ActivityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("[Action]/{id}")]
        [HttpPut]
        public IActionResult UpdateActivity(int id, ActivityDTO activityDto)
        {           
            Activity activity = _unitOfWork._activities.GetById(id);
            if (activity == null)
            {
                return NotFound("Activity doesn't exist");
            }
            activity.Update(activityDto);
            _unitOfWork._activities.Update(activity);
            _unitOfWork.Commit();
            return Ok();
        }

        [Route("[Action]/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Activity activity = _unitOfWork._activities.GetById(id);
            if (activity == null)
            {
                return NotFound("Activity doesn't exist");
            }
            _unitOfWork._activities.Delete(id);
            _unitOfWork.Commit();
            return Ok();
        }
    }
}
