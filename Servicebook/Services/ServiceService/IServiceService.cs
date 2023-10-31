using Servicebook.Models;

namespace Servicebook.Services.ServiceService
{
    public interface IServiceService
    {
        List<Service> GetServices();
        Service? GetService(int id);
        List<Service> AddService(Service service);
        List<Service>? UpdateService(int id, Service service);
        List<Service>? DeleteService(int id);
    }
}
