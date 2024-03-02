using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore;

public class TicketRepository : RepositoryBase<Ticket> , ITicketRepository
{
    public TicketRepository(RepositoryContext context) : base(context)
    {
    }
    public async Task<PagedList<Ticket>> GetAllTicketsAsync(TicketParameters ticketParameters,
        bool trackChanges)
    {
        var ticket = await FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToListAsync();
        return PagedList<Ticket>
            .ToPagedList(ticket, ticketParameters.PageNumber, ticketParameters.PageSize);
    }

    
    public async Task<Ticket> GetOneTicketByIdAsync(int id, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    
    
    
    public void CreateOneTicket(Ticket ticket) => Create(ticket);


    public void UpdateOneTicket(Ticket ticket) => Update(ticket);
    

    public void DeleteOneTicket(Ticket ticket) => Delete(ticket);
}