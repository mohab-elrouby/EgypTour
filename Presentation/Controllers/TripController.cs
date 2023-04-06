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
        public TripController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("[Action]/{id}")]
        [HttpGet]
        public IActionResult GetByID(int id)
        {
            Trip trip = _unitOfWork.Trips.Find(predicate: i => i.Id == id, includeProperties: "Owner,TripViewers,ToDoLists.ToDoItems,Activities").FirstOrDefault();
            if (trip == null)
            {
                return NotFound("trip Doesn't exist");
            }
            TripDTO tripDTO = TripDTO.FromTrip(trip);
            return Ok(tripDTO);
        }

        [Route("[Action]/{id}")]
        [HttpGet]

        public IActionResult GetAllTrips(int id, int skip = 0, int take = 8)
        {

            List<TripCardDTO> trips = _unitOfWork.Trips.Find(predicate: x => x.Owner.Id == id
            || x.TripViewers.Where(b => b.Id == id).Any(), skip: skip, take: take)
           .Select(trip => TripCardDTO.FromTrip(trip)).ToList();

            if (trips == null)
            {
                return NotFound("Trip List is Empty");
            }
            return Ok(trips);
        }

        [Route("[Action]")]
        [HttpPost]
        public async Task<IActionResult> AddActivity(int tripId, [FromBody] ActivityDTO activityDTO)
        {
            Trip trip = _unitOfWork.Trips.GetById(tripId);

            if (trip != null)
            {
                trip.AddActivity(activityDTO);
                _unitOfWork.Commit();
                return Ok();
            }
            else
            {
                return NotFound("Trip doesn't exist");
            }
        }

    }
}
