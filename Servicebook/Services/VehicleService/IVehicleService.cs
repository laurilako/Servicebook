using Microsoft.AspNetCore.Mvc;
using Servicebook.Dtos;
using Servicebook.Models;

namespace Servicebook.Services.VehicleService
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetVehicles();
        Task<ActionResult<Vehicle>>? GetVehicle(int id);
        Task<List<Vehicle>> AddVehicle(VehicleCreateDto request);
        Task<List<Vehicle>>? UpdateVehicle(int id, Vehicle vehicle);
        Task<List<Vehicle>>? DeleteVehicle(int id);
        Task<Vehicle>? AddServiceToVehicle(Service service, int vehId);
        Task<Vehicle>? DeleteServiceFromVehicle(int vehId, int servId);
    }
}
