using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Interfaces.UseCaseInterfaces;
using Domain.Services;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAddServiceReviewUseCase   _addServiceReviewUseCase;
        public ServiceController(IUnitOfWork unitOfWork , IAddServiceReviewUseCase addServiceReviewUseCase)
        { 
            _unitOfWork= unitOfWork;
            _addServiceReviewUseCase= addServiceReviewUseCase;
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {

            Service service = _unitOfWork._services.GetById(id);
            if(service == null)
            {
                return NotFound("Service Doesn't Exist");
            }
            ServiceDTO serviceDTO = ServiceDTO.FromService(service);
            return Ok(serviceDTO);
        }


        [Route("/[Action]")]
        [HttpPost]
        public IActionResult Update([FromHeader] int id ,[FromBody] ServiceDTO serviceDto)
        {
            Service service = _unitOfWork._services.GetById(id);
            if(service != null)
            {
                service.Update(serviceDto);
                _unitOfWork._services.Update(service);
                _unitOfWork.Commit();
                return Ok();
            }
            return NotFound("Service Doesn't exist");
        }
        [Route("/Create")]
        [HttpPut]
        public async Task<IActionResult> Create(ServiceDTO serviceDto)
        {

            Service service = new Service(serviceDto.Name,
                serviceDto.Description,
                serviceDto.WorkingHoursStart,
                serviceDto.WorkingHoursEnd, serviceDto.phone,
                serviceDto.Location,
                serviceDto.ProfileImage
                );
            await _unitOfWork._services.AddAsync(service);
            _unitOfWork.Commit();
            return Ok();
        }
        [Route("[Action]/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Service service = await _unitOfWork._services.Delete(id);            
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            _unitOfWork.Commit();
            return Ok();
        }
        [Route("/[Action]")]
        [HttpGet]
        public IActionResult Search(string searchString, CityName? city=null, int skip=0 ,int take=8,float rating = 0)
        {
            if (city != null)
            {
                List<ServiceSearchDTO> matchingItems = new List<ServiceSearchDTO>();
                if (searchString != "")
                {
                    matchingItems.AddRange(_unitOfWork._services.Search(rating, searchString, city, skip, take).ToList());
                    return Ok(matchingItems);
                }
                else
                {
                    return BadRequest("Can't search with empty string");
                }
            }
            else
            {
                return BadRequest("you must specify a city");
            }                
        }
        [Route("/[Action]")]
        [HttpPost]
        public IActionResult AddReview([FromHeader]int userId,[FromBody]ReviewDTO review,[FromHeader]int serviceId)
        {
            try
            {
                _addServiceReviewUseCase.AddReview(review, serviceId, userId);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode(409,ex.Message);      
            }
        }
    }
}
