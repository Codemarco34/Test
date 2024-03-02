namespace Repositories.Contracts;

public interface IRepositoryManager
{
    ICustomerRepository Customer { get; }
    Task SaveAsync();
    IMaintenanceRepository Maintenance { get; }
    ITicketRepository Ticket { get; }
    
}