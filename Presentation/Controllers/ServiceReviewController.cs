using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServiceReviewController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceReviewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;

        }

        [Route("[Action]/{id}")]
        [HttpGet]
        public GenericResponse<List<ServiceReviewDTO>> GetAllByServiceId(int id, int skip = 0, int take = 8)
        {
            try
            {
                List<ServiceReviewDTO> serviceReviews = _unitOfWork._serviceReviews.GetByServiceId(id, skip, take)
                    .Select(review => ServiceReviewDTO.fromServiceReview(review)).ToList();
                if (serviceReviews.Count()== 0)
                {
                    return new GenericResponse<List<ServiceReviewDTO>>()
                    {
                        StatusCode = 404,
                        Message = "No Reviews Found",

                    };
                }
                else
                {

                    return new GenericResponse<List<ServiceReviewDTO>>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull",
                        Data = serviceReviews

                    };
                }

            }
            catch
            {
                return new GenericResponse<List<ServiceReviewDTO>>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }

        [Route("[Action]/{id}")]

        [HttpGet]
        public GenericResponse<List<ServiceReviewDTO>> GetAllByTouristId(int id, int skip = 0, int take = 8)
        {
            try
            {
                List<ServiceReviewDTO> serviceReviews = _unitOfWork._serviceReviews.GetByTouristId(id, skip, take)
                    .Select(review => ServiceReviewDTO.fromServiceReview(review)).ToList();
                if (serviceReviews.Count()== 0)
                {
                    return new GenericResponse<List<ServiceReviewDTO>>()
                    {
                        StatusCode = 404,
                        Message = "No Reviews Found",

                    };
                }
                else
                {

                    return new GenericResponse<List<ServiceReviewDTO>>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull",
                        Data = serviceReviews

                    };
                }

            }
            catch
            {
                return new GenericResponse<List<ServiceReviewDTO>>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }


        //[HttpPost]
        //public GenericResponse<ServiceReviewDTO> Add([FromBody] ServiceReviewDTO serviceReviewsDto)
        //{
        //    try
        //    {
        //        if (serviceReviewsDto == null)
        //        {
        //            return new GenericResponse<ServiceReviewDTO>()
        //            {
        //                StatusCode = 404,
        //                Message = "No Reviews Found",

        //            };
        //        }
        //        else
        //        {

        //            _unitOfWork.ServiceReviews.Add(serviceReview);
        //            _unitOfWork.Commit();
        //            return new GenericResponse<ServiceReviewDTO>()
        //            {
        //                StatusCode = 200,
        //                Message = "The Process of Get Data Sucessfull",
        //                Data = serviceReviewsDto

        //            };
        //        }

        //    }
        //    catch
        //    {
        //        return new GenericResponse<ServiceReviewDTO>()
        //        {
        //            StatusCode = 500,
        //            Message = "Internal Error",

        //        };
        //    }

        //}



        [Route("[Action]/{id}")]

        [HttpPut]
        public IActionResult Update(int id, int newRating, string newContent)
        {
            try
            {

                ServiceReview serviceReview = _unitOfWork._serviceReviews.GetById(id);
                if (serviceReview == null)
                {
                    return NotFound();
                }

                try
                {
                    serviceReview.UpdateReview(newRating, newContent);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    return BadRequest(e.Message);
                }


                _unitOfWork._serviceReviews.Update(serviceReview);
                _unitOfWork.Commit();
                return Ok();


            }
            catch
            {
                return StatusCode(500);
            }

        }

        [Route("[Action]/{id}")]

        [HttpDelete]
        public GenericResponse<ServiceReviewDTO> Delete(int id)
        {
            var localReview = _unitOfWork._serviceReviews.GetById(id);
            try
            {
                if (localReview == null)
                {
                    return new GenericResponse<ServiceReviewDTO>()
                    {
                        StatusCode = 404,
                        Message = "No Reviews Found",

                    };
                }
                else
                {
                    _unitOfWork._serviceReviews.Delete(id);
                    _unitOfWork.Commit();
                    return new GenericResponse<ServiceReviewDTO>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull"

                    };
                }
            }


            catch
            {
                return new GenericResponse<ServiceReviewDTO>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }
    }
}
