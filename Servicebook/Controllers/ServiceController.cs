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
            return await _serviceService.GetServices();
        }

        // GET: api/Service/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Service>>> GetService(int id)
        {
            var result = await _serviceService.GetService(id);
            if(result == null)
            {
                return NotFound("Service not found!");
            }
            return Ok(result);
        }

        //// POST: api/Service
        //[HttpPost]
        //public async Task<ActionResult<List<Service>>> AddService(Service service)
        //{
        //    var result = await _serviceService.AddService(service);
        //    return Ok(result);
        //}

        // PUT: api/Service/5
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Service>>> UpdateService(int id, Service service)
        {
            var result = await _serviceService.UpdateService(id, service);
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
            var result = await _serviceService.DeleteService(id);
            if(result == null)
            {
                return NotFound("Service not found!");
            }
            return Ok(result);
        }

        // POST: api/service
        [HttpPost]
        public async Task<ActionResult<List<Service>>> AddService(Service service)
        {
            var result = await _serviceService.AddService(service);
            return Ok(result);
        }

        //// POST: api/service/vehicle/5
        //[HttpPost]
        //[Route("vehicle/{id}")]
        //public async Task<ActionResult<List<Service>>> AddServiceToVehicle(int id, Service service)
        //{
        //    var result = await _serviceService.AddServiceToVehicle(service, id);
        //    return Ok(result);
        //}

    }
}
