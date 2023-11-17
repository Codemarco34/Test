namespace Services.Contracts;

public interface IServiceManager
{
    ICustomerService CustomerService { get; }
    IMaintenanceService MaintenanceService { get; }
}