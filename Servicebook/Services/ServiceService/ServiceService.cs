using Servicebook.Models;

namespace Servicebook.Services.ServiceService
{
    public class ServiceService : IServiceService
    {
        private static List<Service> services = new List<Service>
        {
            new Service { Id = 1, VehicleId = 1, Date = DateTime.Now, Name="Oil", Description = "Oil change", Cost = 100 },
            new Service { Id = 2, VehicleId = 1, Date = DateTime.Now, Name="Tire", Description = "Tire change", Cost = 200 },
            new Service { Id = 3, VehicleId = 2, Date = DateTime.Now, Name="Oil", Description = "Oil change", Cost = 100 }
        };

        public List<Service> GetServices()
        {
            return services;
        }

        public Service? GetService(int id)
        {
            var service = services.FirstOrDefault(s => s.Id == id);
            if(service == null)
            {
                return null;
            }
            return service;
        }

        public List<Service> AddService(Service service)
        {
            services.Add(service);
            return services;
        }

        public List<Service>? UpdateService(int id, Service service)
        {
            var serviceToUpdate = services.FirstOrDefault(s => s.Id == id);
            if(serviceToUpdate == null)
            {
                return null;
            }
            serviceToUpdate.VehicleId = service.VehicleId;
            serviceToUpdate.Date = service.Date;
            serviceToUpdate.Name = service.Name;
            serviceToUpdate.Description = service.Description;
            serviceToUpdate.Cost = service.Cost;
            return services;
        }

        public List<Service>? DeleteService(int id)
        {
            var serviceToDelete = services.FirstOrDefault(s => s.Id == id);
            if(serviceToDelete == null)
            {
                return null;
            }
            services.Remove(serviceToDelete);
            return services;
        }
    }
}
