using Microsoft.AspNetCore.Mvc;
using Servicebook.Dtos;
using Servicebook.Models;

namespace Servicebook.Services.VehicleService
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetVehicles();
        Task<ActionResult<Vehicle>>? GetVehicle(int id);
        Task<ActionResult<Vehicle>>? GetVehicleByLicensePlate(string licensePlate);
        Task<List<Vehicle>> AddVehicle(VehicleCreateDto request);
        Task<Vehicle>? UpdateVehicle(string licensePlate, Vehicle vehicle);
        Task<List<Vehicle>>? DeleteVehicle(string licensePlate);
        Task<Vehicle>? AddServiceToVehicle(Service service, int vehId);
        Task<Vehicle>? DeleteServiceFromVehicle(int vehId, int servId);
    }
}
