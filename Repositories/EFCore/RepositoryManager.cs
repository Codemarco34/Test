using Repositories.Contracts;

namespace Repositories.EFCore;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    private readonly Lazy<ICustomerRepository> _customerRepository;
    private readonly Lazy<MaintenanceRepository> _maintenanceRepository;

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
        _customerRepository = new Lazy<ICustomerRepository>(()=>new CustomerRepository(_context));
        _maintenanceRepository = new Lazy<MaintenanceRepository>(() => new MaintenanceRepository(_context));
        
    }

    public ICustomerRepository Customer => _customerRepository.Value;
    public IMaintenanceRepository Maintenance => _maintenanceRepository.Value;
    
    public void Save()
    {
        _context.SaveChanges();
    }
}