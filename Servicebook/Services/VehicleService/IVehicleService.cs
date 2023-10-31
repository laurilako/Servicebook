using Servicebook.Models;

namespace Servicebook.Services.VehicleService
{
    public interface IVehicleService
    {
        List<Vehicle> GetVehicles();
        Vehicle? GetVehicle(int id);
        List<Vehicle> AddVehicle(Vehicle vehicle);
        List<Vehicle>? UpdateVehicle(int id, Vehicle vehicle);
        List<Vehicle>? DeleteVehicle(int id);
    }
}
