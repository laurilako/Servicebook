using Servicebook.Models;

namespace Servicebook.Services.ServiceService
{
    public interface IServiceService
    {
        Task<List<Service>> GetServices();
        Task<Service>? GetService(int id);
        Task<List<Service>> AddService(Service service);
        //Task<List<Service>> AddServiceToVehicle(Service service, int vehId);
        Task<List<Service>>? UpdateService(int id, Service service);
        Task<List<Service>>? DeleteService(int id);
    }
}
