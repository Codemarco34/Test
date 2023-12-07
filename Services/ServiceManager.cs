using AutoMapper;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IMaintenanceService> _maintenanceService; 
    private readonly Lazy<ICustomerService> _customerService; 
    public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger, IMapper mapper)
    {
        _customerService = new Lazy<ICustomerService>(()=>new CustomerManager(repositoryManager, logger,mapper));
        _maintenanceService = new Lazy<IMaintenanceService>(() => new MaintenanceManager(repositoryManager,logger,mapper));
    }
    public ICustomerService CustomerService => _customerService.Value;

    public IMaintenanceService MaintenanceService => _maintenanceService.Value;
}