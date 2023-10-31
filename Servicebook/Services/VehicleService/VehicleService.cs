using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Servicebook.Data;
using Servicebook.Models;

namespace Servicebook.Services.VehicleService
{
    public class VehicleService : IVehicleService
    {
        private readonly DataContext _dataContext;

        public VehicleService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Vehicle>> AddVehicle(Vehicle vehicle)
        {
            await _dataContext.Vehicles.AddAsync(vehicle);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Vehicles.ToListAsync();
        }

        public async Task<List<Vehicle>>? DeleteVehicle(int id)
        {
            var vehicleToDelete = await _dataContext.Vehicles.FindAsync(id);
            if (vehicleToDelete is null) return null;

            _dataContext.Vehicles.Remove(vehicleToDelete);

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Vehicles.ToListAsync();
        }

        public async Task<Vehicle>? GetVehicle(int id)
        {
            var vehicle = await _dataContext.Vehicles.FindAsync(id);
            if (vehicle is null) return null;
            return vehicle;
        }

        //public List<Service>? GetVehicleServices(int id)
        //{
        //    var vehicle = vehicles.FirstOrDefault(v => v.Id == id);
        //    if (vehicle is null) return null;

        //    return vehicle.Services;
        //}

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _dataContext.Vehicles.ToListAsync();
        }

        public async Task<List<Vehicle>>? UpdateVehicle(int id, Vehicle vehicle)
        {
            var vehicleToUpdate = await _dataContext.Vehicles.FindAsync(id);
            if (vehicleToUpdate is null) return null;
            vehicleToUpdate.Brand = vehicle.Brand;
            vehicleToUpdate.Type = vehicle.Type;
            vehicleToUpdate.ModelName = vehicle.ModelName;
            vehicleToUpdate.LicensePlate = vehicle.LicensePlate;
            vehicleToUpdate.Year = vehicle.Year;
            vehicleToUpdate.Color = vehicle.Color;

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Vehicles.ToListAsync();
        }
    }
}
