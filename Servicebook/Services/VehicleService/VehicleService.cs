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
            // check if vehicle with license plate already exists
            var vehicleExists = await _dataContext.Vehicles
                .FirstOrDefaultAsync(v => v.LicensePlate == request.LicensePlate);
            if (vehicleExists != null) throw new Exception("Vehicle with this license plate already exists!");

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

        // update vehicle by license plate
        public async Task<Vehicle>? UpdateVehicle(string licensePlate, Vehicle vehicle)
        {
            var vehToUpdate = await _dataContext.Vehicles.
                FirstOrDefaultAsync(v => v.LicensePlate == licensePlate);
            if (vehToUpdate is null) throw new Exception("Vehicle not found!");

            vehToUpdate.Brand = vehicle.Brand;
            vehToUpdate.Type = vehicle.Type;
            vehToUpdate.ModelName = vehicle.ModelName;
            vehToUpdate.LicensePlate = vehicle.LicensePlate;
            vehToUpdate.Year = vehicle.Year;
            vehToUpdate.Color = vehicle.Color;

            await _dataContext.SaveChangesAsync();

            return vehicle;
        }

        public async Task<List<Vehicle>>? DeleteVehicle(string licensePlate)
        {
            var vehToDelete = await _dataContext.Vehicles.
                FirstOrDefaultAsync(v => v.LicensePlate == licensePlate);
            if (vehToDelete is null) throw new Exception("Vehicle not found!");

            _dataContext.Vehicles.Remove(vehToDelete);
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

        public async Task<ActionResult<Vehicle>>? GetVehicleByLicensePlate(string licensePlate)
        {
            var vehicle = await _dataContext.Vehicles
                .Include(v => v.Services)
                .FirstOrDefaultAsync(c => c.LicensePlate == licensePlate);
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
