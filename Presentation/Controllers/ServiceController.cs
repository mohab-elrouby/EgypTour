using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Interfaces.UseCaseInterfaces;
using Domain.Services;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Services;

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

        [Route("[Action]/{id}")]
        [HttpGet]

        public IActionResult GetById(int id)
        {

            Service service = _unitOfWork._services.Find(i=>i.Id==id,includeProperties: "Reviews.Reviwer,Location").FirstOrDefault();
            if(service == null)
            {
                return NotFound("Service Doesn't Exist");
            }
            ServiceDTO serviceDTO = ServiceDTO.FromService(service);
            return Ok(serviceDTO);
        }

        [Route("[Action]/{city}")]
        [HttpGet]
        public IActionResult GetAllByCity(CityName city,int skip=0,int take=8)
        {
            int count = _unitOfWork._services.Find(predicate: i => i.Location.CityName == city, take: 8000).Count();

            List<ServiceSearchDTO> services = _unitOfWork._services.Find(predicate: i => i.Location.CityName == city, includeProperties: "Reviews.Reviwer,Location,Images",
                orderBy: i => i.OrderByDescending(a => a.Reviews.Average(b => b.Rating)), skip: skip, take: take).
                Select(i => ServiceSearchDTO.FromService(service: i, avgRating: i.Reviews.Average(a => a.Rating), firstReview: i.Reviews.FirstOrDefault().Content)).ToList();


            return Ok(new { Count = count, Services = services });
        }


        [Route("[Action]")]
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
        [Route("[Action]")]
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
        [Route("[Action]")]
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
        [Route("[Action]")]
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

        [Route("[Action]")]
        [HttpPost]
        public IActionResult UpdateProfileImage([FromForm] IFormFile file, int serviceId)
        {
            Service service = _unitOfWork._services.GetById(serviceId);
            if (service == null)
            {
                return NotFound("Service doesn't exist");
            }
            if(service.ProfileImage != "")
            {
                try
                {
                    WriteDeleteFileService.Delete(service.ProfileImage);
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }       
            }
            string uniqueName = WriteDeleteFileService.Write(file, "wwwroot/service-images/");
            string fullImagePath = $"/service-images/{uniqueName}";
            service.UpdateProfileImage(fullImagePath);
            _unitOfWork.Commit();
            return Ok();
        }
        [Route("[Action]")]
        [HttpPost]
        public IActionResult AddServiceImage([FromForm] IFormFile file, int serviceId)
        {
            Service service = _unitOfWork._services.GetById(serviceId);
            if (service == null)
            {
                return NotFound("Service doesn't exist");
            }

            string uniqueName = WriteDeleteFileService.Write(file, "wwwroot/service-images/");
            string imageUrl = $"/service-images/{uniqueName}";
            service.AddImage(imageUrl);
            _unitOfWork.Commit();
            return Ok("image uploaded successfually");
        }

        [HttpPatch("[Action]")]
        public IActionResult DeleteImage(int serviceId, string imagePath)
        {
            Service service = _unitOfWork._services.Find(predicate: i => i.Id == serviceId, includeProperties: "Images").FirstOrDefault();
            if (service == null)
            {
                return NotFound("Trip doesn't exist");
            }
            try
            {
                WriteDeleteFileService.Delete(imagePath);
                service.RemoveImage(imagePath);
                _unitOfWork.Commit();
                return Ok("Image Deleted successfually");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Can't Delete image , Try Again Later");
            }
        }
    }
}
