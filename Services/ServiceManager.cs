using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IMaintenanceService> _maintenanceService; 
    private readonly Lazy<ICustomerService> _customerService; 
    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _customerService = new Lazy<ICustomerService>(()=>new CustomerManager(repositoryManager));
        _maintenanceService = new Lazy<IMaintenanceService>(() => new MaintenanceManager(repositoryManager));
    }
    public ICustomerService CustomerService => _customerService.Value;

    public IMaintenanceService MaintenanceService => _maintenanceService.Value;
}