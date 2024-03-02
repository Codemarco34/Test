using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IMaintenanceService> _maintenanceService; 
    private readonly Lazy<ICustomerService> _customerService;
    private readonly Lazy<ITicketService> _ticketService;
    private readonly Lazy<IAuthenticationService> _authenticationservice;
    public ServiceManager(
        IRepositoryManager repositoryManager, 
        ILoggerService logger, 
        IMapper mapper, 
        IConfiguration configuration, 
        UserManager<User> userManager)
    {
       
        _ticketService = new Lazy<ITicketService>(() => new TicketManager(repositoryManager, logger, mapper));
        _customerService = new Lazy<ICustomerService>(()=>new CustomerManager(repositoryManager, logger,mapper));
        _maintenanceService = new Lazy<IMaintenanceService>(() => new MaintenanceManager(repositoryManager,logger,mapper));
        _authenticationservice = new Lazy<IAuthenticationService>(()=> new AuthenticationManager(logger,mapper,userManager,configuration));
    }
    public ICustomerService CustomerService => _customerService.Value;

    public IMaintenanceService MaintenanceService => _maintenanceService.Value;

    public ITicketService TicketService => _ticketService.Value;
    public IAuthenticationService AuthenticationService => _authenticationservice.Value;
}