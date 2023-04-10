using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Response;
using Domain.DTOs;
using Domain.Entities;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocalReviewController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
       
        
        public LocalReviewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
            
        }


        [Route("[Action]/{id}")]

        [HttpGet]
        public GenericResponse<List<LocalReviewDTO>> GetAllByLocalPersonId(int id , int skip=0 , int take = 8)
        {
            try
            {
                List<LocalReviewDTO> localReviews = _unitOfWork.LocalReviews.GetByLocalPersonId(id,skip,take)
                    .Select(review => LocalReviewDTO.fromLocalReview(review)).ToList();
                if (localReviews.Count() == 0)
                {
                    return new GenericResponse<List<LocalReviewDTO>>()
                    {
                        StatusCode = 404,
                        Message = "No Reviews Found",

                    };
                }
                else
                {
                   
                   
                    return new GenericResponse<List<LocalReviewDTO>>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull",
                        Data = localReviews

                    };
                }
                
            }
            catch
            {
                return new GenericResponse<List<LocalReviewDTO>>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }


        [Route("[Action]/{id}")]

        [HttpPut]
        public IActionResult Update( int id, int newRating , string newContent)
        {
            try
            {
            
                LocalReview localReview = _unitOfWork.LocalReviews.GetById(id);
                if (localReview == null)
                {
                    return NotFound();
                }

                try
                {
                    localReview.UpdateReview(newRating, newContent);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    return BadRequest(e.Message);
                }

                
                    _unitOfWork.LocalReviews.Update(localReview);
                    _unitOfWork.Commit();
                return Ok();
               

            }
            catch
            {
                return StatusCode(500);
            }

        }

        // DELETE api/<LocalReviewsController>/5

        [Route("[Action]/{id}")]
        [HttpDelete]
        public GenericResponse<LocalReviewDTO> Delete(int id)
        {
            LocalReview localReview = _unitOfWork.LocalReviews.GetById(id);
            try
            {
                if (localReview == null)
                {
                    return new GenericResponse<LocalReviewDTO>()
                    {
                        StatusCode = 404,
                        Message = "No Reviews Found",

                    };
                }
                else
                {
                    _unitOfWork.LocalReviews.Delete(id);
                    _unitOfWork.Commit();
                    return new GenericResponse<LocalReviewDTO>()
                    {
                        StatusCode = 200,
                        Message = "The Process of Get Data Sucessfull"

                    };
                }
            }
           

             catch
            {
                return new GenericResponse<LocalReviewDTO>()
                {
                    StatusCode = 500,
                    Message = "Internal Error",

                };
            }
        }
    }
}
