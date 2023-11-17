namespace Repositories.Contracts;

public interface IRepositoryManager
{
    ICustomerRepository Customer { get; }
    void Save();
    IMaintenanceRepository Maintenance { get; }
    
}