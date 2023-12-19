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

        // GET: api/Vehicle/licensePlate/ABC123
        [HttpGet("licensePlate/{licensePlate}")]
        public async Task<ActionResult<List<Vehicle>>> GetVehicleByLicensePlate(string licensePlate)
        {
            var result = await _vehicleService.GetVehicleByLicensePlate(licensePlate);
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
            List<Vehicle> result;
            try
            {
                result = await _vehicleService.AddVehicle(request);
                return Ok(result);
            } catch (Exception e)
            {
                if (e.Message == "Vehicle with this license plate already exists!")
                {
                    return StatusCode(StatusCodes.Status409Conflict, e.Message);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT: api/Vehicle/XXX123
        [HttpPut("{licensePlate}")]
        public async Task<ActionResult<Vehicle>> UpdateVehicle(string licensePlate, Vehicle vehicle)
        {
            Vehicle result;
            try
            {
                result = await _vehicleService.UpdateVehicle(licensePlate, vehicle);
                return Ok(result);
            } catch (Exception e)
            {
                if (e.Message == "Vehicle not found!") return StatusCode(StatusCodes.Status404NotFound, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // DELETE: api/Vehicle/XXX123
        [HttpDelete("{licensePlate}")]
        public async Task<ActionResult<List<Vehicle>>> DeleteVehicle(string licensePlate)
        {
            try
            {
                var result = await _vehicleService.DeleteVehicle(licensePlate);
                return Ok(result);
            } catch (Exception e)
            {
                if (e.Message == "Vehicle not found!")
                {
                    return StatusCode(StatusCodes.Status404NotFound, e.Message);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
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
