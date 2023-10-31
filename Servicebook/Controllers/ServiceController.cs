using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicebook.Models;
using Servicebook.Services.ServiceService;

namespace Servicebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET: api/Service
        [HttpGet]
        public async Task<ActionResult<List<Service>>> GetServices()
        {
            var result = _serviceService.GetServices();
            return Ok(result);
        }

        // GET: api/Service/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<List<Service>>> GetService(int id)
        {
            var result = _serviceService.GetService(id);
            if(result == null)
            {
                return NotFound("Service not found!");
            }
            return Ok(result);
        }

        // POST: api/Service
        [HttpPost]
        public async Task<ActionResult<List<Service>>> AddService(Service service)
        {
            var result = _serviceService.AddService(service);
            return Ok(result);
        }

        // PUT: api/Service/5
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Service>>> UpdateService(int id, Service service)
        {
            var result = _serviceService.UpdateService(id, service);
            if(result == null)
            {
                return NotFound("Service not found!");
            }
            return Ok(result);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Service>>> DeleteService(int id)
        {
            var result = _serviceService.DeleteService(id);
            if(result == null)
            {
                return NotFound("Service not found!");
            }
            return Ok(result);
        }
    }
}
