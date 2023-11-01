using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Servicebook.Data;
using Servicebook.Dtos;
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

        public async Task<List<Vehicle>> AddVehicle(VehicleCreateDto request)
        {
            var vehicle = new Vehicle
            {
                Brand = request.Brand,
                Type = request.Type,
                ModelName = request.ModelName,
                LicensePlate = request.LicensePlate,
                Year = request.Year,
                Color = request.Color
            };
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

        public async Task<ActionResult<Vehicle>>? GetVehicle(int id)
        {
            var vehicle = await _dataContext.Vehicles
                .Include(v => v.Services)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (vehicle is null) return null;
            return vehicle;
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            var vehicles = await _dataContext.Vehicles
                .Include(v => v.Services)
                .ToListAsync();
            if(vehicles is null) return null;
            return vehicles;
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
        public async Task<Vehicle> AddServiceToVehicle(Service service, int vehId)
        {
            // find vehicle by id
            Vehicle vehicle = await _dataContext.Vehicles.FindAsync(vehId);
            if (vehicle is null) return null;

            // add service to vehicle
            vehicle.Services.Add(service);
            await _dataContext.SaveChangesAsync();

            return vehicle;
        }
        public async Task<Vehicle>? DeleteServiceFromVehicle(int vehId, int servId)
        {
            // find vehicle by id
            Vehicle vehicle = await _dataContext.Vehicles.FindAsync(vehId);
            if (vehicle is null) return null;

            // find service by id
            Service service = await _dataContext.Services.FindAsync(servId);
            if (service is null) return null;

            // remove service from vehicle
            vehicle.Services.Remove(service);
            
            // remove service from database
            _dataContext.Services.Remove(service);

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Vehicles
                .Include(v => v.Services)
                .FirstOrDefaultAsync(c => c.Id == vehId);
        }
    }
}
