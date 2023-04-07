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
        public IActionResult AddActivity(int tripId, [FromBody] ActivityDTO activityDTO)
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

        [Route("[Action]")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Trip trip = _unitOfWork.Trips.GetById(id);
            if(trip == null)
            {
                return NotFound("Trip doesn't exist or Already Deleted");
            }
            _unitOfWork.Trips.Delete(id);
            _unitOfWork.Commit();
            return Ok();
        }

        [Route("[Action]")]
        [HttpPut]
        public IActionResult Update([FromHeader] int id, [FromBody] TripDTO tripDto)
        {
            Trip trip = _unitOfWork.Trips.GetById(id);
            if (trip == null)
            {
                return NotFound("Trip doesn't exist or Already Deleted");
            }
            trip.Update(tripDto);
            _unitOfWork.Trips.Update(trip);
            _unitOfWork.Commit();
            return Ok();
        }

        [Route("[Action]")]
        [HttpGet]
        public IActionResult GetActivityRecommendition(int id)
        {
            Trip trip = _unitOfWork.Trips.GetById(id);
            if (trip == null)
            {
                return NotFound("Trip doesn't exist or Already Deleted");
            }
            // missing rating 
            List <Service> services = _unitOfWork._services.Find(predicate:x => x.Location.CityName == trip.Location.CityName).ToList();
            return Ok();
        }

        [Route("[Action]")]
        [HttpPost]
        public IActionResult AddToDOList([FromHeader] int id, [FromBody] ToDOListDTO toDOListDTO)
        {
            Trip trip = _unitOfWork.Trips.GetById(id);
            if (trip == null)
            {
                return NotFound("Trip doesn't exist or Already Deleted");
            }
            trip.AddToDoList(toDOListDTO);
            _unitOfWork.Commit();
            return Ok();
        }

        [Route("[Action]/{ActivityId}")]
        [HttpGet]
        public IActionResult GetCityRecommendations(CityName city)
        {
            List<ServiceRecommendationDTO> serviceRecommendations = _unitOfWork._services.Find(predicate: x => x.Location.CityName == city, orderBy: a => a.OrderBy(b => b.Reviews.Average(c => c.Rating)))
                .Select(i => ServiceRecommendationDTO.FromService(i, i.Reviews.Average(a => a.Rating))).ToList();

            List<LocalPersonRecommendationDTO> localPeopleRecommendations = _unitOfWork._localPersons.Find(predicate: x => x.City == city, orderBy: a => a.OrderBy(b => b.Reviews.Average(c => c.Rating)))
                .Select(i => LocalPersonRecommendationDTO.FromLocalPerson(i, i.Reviews.Average(a => a.Rating))).ToList();

            RecommendationsDto recommendationsDto = new RecommendationsDto()
            {
                serviceRecommendations = serviceRecommendations,
                localPersonRecommendations = localPeopleRecommendations
            }; 
            return Ok(recommendationsDto);
        }

    }

}
