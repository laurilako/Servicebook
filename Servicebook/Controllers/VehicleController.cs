using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicebook.Dtos;
using Servicebook.Models;
using Servicebook.Services.VehicleService;

namespace Servicebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: api/Vehicle
        [HttpGet]
        public async Task<ActionResult<List<Vehicle>>> GetVehicles()
        {
            var result = await _vehicleService.GetVehicles();
            return Ok(result);
        }

        // GET: api/Vehicle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Vehicle>>> GetVehicle(int id)
        {
            var result = await _vehicleService.GetVehicle(id);
            if(result == null)
            {
                return NotFound("Vehicle not found!");
            }
            return Ok(result);
        }

        // POST: api/Vehicle
        [HttpPost]
        public async Task<ActionResult<List<Vehicle>>> AddVehicle(VehicleCreateDto request)
        {
            var result = await _vehicleService.AddVehicle(request);
            return Ok(result);
        }

        // PUT: api/Vehicle/5
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Vehicle>>> UpdateVehicle(int id, Vehicle vehicle)
        {
            var result = await _vehicleService.UpdateVehicle(id, vehicle);
            if(result == null)
            {
                return NotFound("Vehicle not found!");
            }
            return Ok(result);
        }

        // DELETE: api/Vehicle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Vehicle>>> DeleteVehicle(int id)
        {
            var result = await _vehicleService.DeleteVehicle(id);
            if(result == null)
            {
                return NotFound("Vehicle not found!");
            }
            return Ok(result);
        }

        // POST: api/Vehicle/5/service/
        [HttpPost("{id}/service")]
        public async Task<ActionResult<List<Vehicle>>> AddServiceToVehicle(Service service, int id)
        {
            var result = await _vehicleService.AddServiceToVehicle(service, id);
            if(result == null)
            {
                return NotFound("Vehicle not found!");
            }
            return Ok(result);
        }

        //DELETE: api/Vehicle/5/service/1
        [HttpDelete("{id}/service/{serviceId}")]
        public async Task<ActionResult<List<Vehicle>>> DeleteServiceFromVehicle(int id, int serviceId)
        {
            var result = await _vehicleService.DeleteServiceFromVehicle(id, serviceId);
            if(result == null)
            {
                return NotFound("Vehicle or service not found!");
            }
            return Ok(result);
        }
    }
}
