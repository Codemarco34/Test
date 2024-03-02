namespace Services.Contracts;

public interface IServiceManager
{
    ICustomerService CustomerService { get; }
    IMaintenanceService MaintenanceService { get; }
    ITicketService TicketService { get; }
    IAuthenticationService AuthenticationService { get; }
}