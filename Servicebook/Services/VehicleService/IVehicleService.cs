using Servicebook.Models;

namespace Servicebook.Services.VehicleService
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetVehicles();
        Task<Vehicle>? GetVehicle(int id);
        //List<Service>? GetVehicleServices(int id);
        Task<List<Vehicle>> AddVehicle(Vehicle vehicle);
        Task<List<Vehicle>>? UpdateVehicle(int id, Vehicle vehicle);
        Task<List<Vehicle>>? DeleteVehicle(int id);
    }
}
