using Microsoft.AspNetCore.Http.HttpResults;
using Servicebook.Models;

namespace Servicebook.Services.VehicleService
{
    public class VehicleService : IVehicleService
    {
        private static List<Vehicle> vehicles = new List<Vehicle>
        {
            new Vehicle
            {
                Id = 1,
                Brand = "BMW",
                Type = "X5",
                ModelName = "M",
                LicensePlate = "ABC123",
                Year = 2019,
                Color = "Black"
            },
            new Vehicle
            {
                Id = 2,
                Brand = "Audi",
                Type = "A4",
                ModelName = "S",
                LicensePlate = "DEF456",
                Year = 2018,
                Color = "White"
            },
            new Vehicle
            {
                Id = 3,
                Brand = "Mercedes",
                Type = "C",
                ModelName = "AMG",
                LicensePlate = "GHI789",
                Year = 2017,
                Color = "Red"
            }
        };

        public List<Vehicle> AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            return vehicles;
        }

        public List<Vehicle>? DeleteVehicle(int id)
        {
            var vehicleToDelete = vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicleToDelete is null) return null;
            vehicles.Remove(vehicleToDelete);
            return vehicles;
        }

        public Vehicle? GetVehicle(int id)
        {
            var vehicle = vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicle is null) return null;
            return vehicle;
        }

        public List<Vehicle> GetVehicles()
        {
            return (vehicles);
        }

        public List<Vehicle>? UpdateVehicle(int id, Vehicle vehicle)
        {
            var vehicleToUpdate = vehicles.FirstOrDefault(v => v.Id == id);
            if (vehicleToUpdate is null) return null;
            vehicleToUpdate.Brand = vehicle.Brand;
            vehicleToUpdate.Type = vehicle.Type;
            vehicleToUpdate.ModelName = vehicle.ModelName;
            vehicleToUpdate.LicensePlate = vehicle.LicensePlate;
            vehicleToUpdate.Year = vehicle.Year;
            vehicleToUpdate.Color = vehicle.Color;
            return vehicles;

            
        }
    }
}
