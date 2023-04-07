using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ToDoListController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("[Action]")]
        [HttpPut]
        public IActionResult UpdateToDoList([FromHeader] int id, [FromBody] ToDOListDTO toDOListDTO)
        {
            ToDoList toDoList = _unitOfWork._toDoLists.GetById(id);
            if (toDoList == null)
            {
                return NotFound("Trip doesn't exist or Already Deleted");
            }
            toDoList.Update(toDOListDTO);
            _unitOfWork._toDoLists.Update(toDoList);
            _unitOfWork.Commit();
            return Ok();
        }

        [Route("[Action]")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ToDoList toDoList = _unitOfWork._toDoLists.GetById(id);
            if (toDoList == null)
            {
                return NotFound("Trip doesn't exist or Already Deleted");
            }
            _unitOfWork._toDoLists.Delete(id);
            _unitOfWork.Commit();
            return Ok();
        }
    }
}
