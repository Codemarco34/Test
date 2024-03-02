using System.Data;
using Repositories.Contracts;

namespace Repositories.EFCore;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    private readonly Lazy<ICustomerRepository> _customerRepository;
    private readonly Lazy<MaintenanceRepository> _maintenanceRepository;
    private readonly Lazy<ITicketRepository> _ticketRepository;

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
        _ticketRepository = new Lazy<ITicketRepository>(() => new TicketRepository(_context));
        _customerRepository = new Lazy<ICustomerRepository>(()=>new CustomerRepository(_context));
        _maintenanceRepository = new Lazy<MaintenanceRepository>(() => new MaintenanceRepository(_context));
        
    }

    public ICustomerRepository Customer => _customerRepository.Value;
    public IMaintenanceRepository Maintenance => _maintenanceRepository.Value;
    public ITicketRepository Ticket => _ticketRepository.Value;
    
    public async Task SaveAsync()
    {
       await _context.SaveChangesAsync();
    }
}