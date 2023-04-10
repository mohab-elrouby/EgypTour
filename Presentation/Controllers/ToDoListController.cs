using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ToDoListController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("[Action]/{id}")]
        [HttpPut]
        public IActionResult UpdateToDoList( int id, ToDOListDTO toDOListDTO)
        {
            ToDoList toDoList = _unitOfWork._toDoLists.GetById(id);
            if (toDoList == null)
            {
                return NotFound("ToDoList doesn't exist");
            }
            toDoList.Update(toDOListDTO);
            _unitOfWork._toDoLists.Update(toDoList);
            _unitOfWork.Commit();
            return Ok();
        }

        [Route("[Action]/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ToDoList toDoList = _unitOfWork._toDoLists.GetById(id);
            if (toDoList == null)
            {
                return NotFound("ToDoList doesn't exist or Already Deleted");
            }
            _unitOfWork._toDoLists.Delete(id);
            _unitOfWork.Commit();
            return Ok();
        }
        [Route("[Action]/{id}")]
        [HttpPost]
        public IActionResult AddToDoItem(int id , ToDoItemDTO toDoItemDTO)
        {
            ToDoList toDoList = _unitOfWork._toDoLists.GetById(id);
            if (toDoList == null)
            {
                return NotFound("ToDoList doesn't exist or Already Deleted");
            }
            toDoList.AddToDoItem(toDoItemDTO);
            return Ok();
        }
    }
}
