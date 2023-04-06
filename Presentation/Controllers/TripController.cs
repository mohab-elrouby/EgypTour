using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TripController (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetByID(int id) 
        {
            Trip trip =_unitOfWork.Trips.Find(predicate:i=>i.Id==id,includeProperties: "Owner,TripViewers,ToDoLists.ToDoItems,Activities").FirstOrDefault();
            if (trip == null)
            {
                return NotFound("trip Doesn't exist");
            }
            TripDTO tripDTO = TripDTO.FromTrip(trip);
            return Ok(tripDTO);
        }      
    }
}
