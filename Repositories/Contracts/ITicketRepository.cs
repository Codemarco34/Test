using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts;

public interface ITicketRepository : IRepositoryBase<Ticket>
{
    Task<PagedList<Ticket>> GetAllTicketsAsync(TicketParameters parameters,bool trackChanges);
    Task<Ticket> GetOneTicketByIdAsync (int id ,bool trackChanges);
    void CreateOneTicket(Ticket ticket);
    void UpdateOneTicket(Ticket ticket);
    void DeleteOneTicket(Ticket ticket);
    
}