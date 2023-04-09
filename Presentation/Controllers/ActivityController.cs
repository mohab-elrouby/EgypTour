using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
      
        private readonly IUnitOfWork _unitOfWork;
        public ActivityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("[Action]")]
        [HttpPut]
        public IActionResult UpdateActivity([FromHeader] int id, [FromBody] ActivityDTO activityDto)
        {
            Activity activity = _unitOfWork._activities.GetById(id);
            if (activity == null)
            {
                return NotFound("Trip doesn't exist or Already Deleted");
            }
            activity.Update(activityDto);
            _unitOfWork._activities.Update(activity);
            _unitOfWork.Commit();
            return Ok();
        }

        [Route("[Action]")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Activity activity = _unitOfWork._activities.GetById(id);
            if (activity == null)
            {
                return NotFound("Trip doesn't exist or Already Deleted");
            }
            _unitOfWork._activities.Delete(id);
            _unitOfWork.Commit();
            return Ok();
        }


    }
}
