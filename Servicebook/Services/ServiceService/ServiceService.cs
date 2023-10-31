using Microsoft.EntityFrameworkCore;
using Servicebook.Data;
using Servicebook.Models;

namespace Servicebook.Services.ServiceService
{
    public class ServiceService : IServiceService
    {
        private readonly DataContext _dataContext;

        public ServiceService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Service>> GetServices()
        {
            var services = await _dataContext.Services.ToListAsync();
            return services;
        }

        public async Task<Service?> GetService(int id)
        {
            var service = await _dataContext.Services.FindAsync(id);
            if(service == null)
            {
                return null;
            }
            return await _dataContext.Services.FindAsync(id);
        }

        public async Task<List<Service>> AddService(Service service)
        {
            _dataContext.Services.AddAsync(service);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Services.ToListAsync();
        }

        public async Task<List<Service>>? UpdateService(int id, Service service)
        {
            var serviceToUpdate = await _dataContext.Services.FindAsync(id);
            if (serviceToUpdate == null)
            {
                return null;
            }
            serviceToUpdate.VehicleId = service.VehicleId;
            serviceToUpdate.Date = service.Date;
            serviceToUpdate.Name = service.Name;
            serviceToUpdate.Description = service.Description;
            serviceToUpdate.Cost = service.Cost;
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Services.ToListAsync();
        }

        public async Task<List<Service>>? DeleteService(int id)
        {
            var serviceToDelete = await _dataContext.Services.FindAsync(id);
            if (serviceToDelete == null)
            {
                return null;
            }
            _dataContext.Services.Remove(serviceToDelete);

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Services.ToListAsync();
        }
    }
}
