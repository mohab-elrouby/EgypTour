using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ToDoItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("[Action]/{id}/{name}")]
        [HttpPut]
        public IActionResult UpdateToDoList( int id,string name)
        {
            ToDoItem toDoItem = _unitOfWork._toDoItems.GetById(id);
            if (toDoItem == null)
            {
                return NotFound("Trip doesn't exist or Already Deleted");
            }
            toDoItem.UpdateName(name);
            _unitOfWork._toDoItems.Update(toDoItem);
            _unitOfWork.Commit();
            return Ok();
        }

        [Route("[Action]")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ToDoItem toDoItem = _unitOfWork._toDoItems.GetById(id);
            if (toDoItem == null)
            {
                return NotFound("Trip doesn't exist or Already Deleted");
            }
            _unitOfWork._toDoItems.Delete(id);
            _unitOfWork.Commit();
            return Ok();
        }
        [Route("[Action]/{id}")]
        [HttpPatch]
        public IActionResult MarkDone(int id)
        {
            ToDoItem toDoItem = _unitOfWork._toDoItems.GetById(id);
            
            if (toDoItem == null)
            {
                return NotFound("ToDoItem doesn't exist or Already Deleted");
            }
            toDoItem.MarkDone();
            _unitOfWork.Commit();
            return Ok();
        }

        [Route("[Action]/{id}")]
        [HttpPatch]
        public IActionResult MarkNotDone(int id)
        {
            ToDoItem toDoItem = _unitOfWork._toDoItems.GetById(id);
            if (toDoItem == null)
            {
                return NotFound("ToDoItem doesn't exist or Already Deleted");
            }
            toDoItem.MarkNotDone();
            _unitOfWork.Commit();
            return Ok();
        }
    }
}
