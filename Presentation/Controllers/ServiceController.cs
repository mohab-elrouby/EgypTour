using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ICrudService<ServiceDTO> _serviceService;
        public ServiceController(ICrudService<ServiceDTO> serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            return  Ok(_serviceService.Get(id));
        }

        [HttpPost]

        public IActionResult Update([FromBody] ServiceDTO service)
        {
            _serviceService.Update(service);
            return Ok();
        }
    }
}
