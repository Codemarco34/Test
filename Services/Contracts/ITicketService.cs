using Entities.DTOs;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts;

public interface ITicketService
{
    Task<(IEnumerable<TicketDto> ticket, MetaData metaData)> GetAllTicketAsync (TicketParameters parameters,bool trackChanges);
    Task<TicketDto> GetOneTicketByIdAsync (int id , bool trackChanges);
    Task<TicketDto> CreateOneTicketAsync (TicketDtoForInsertion ticket);
    Task UpdateOneTicketAsync (int id, TicketDto ticketDto,bool trackChanges);
    Task  DeleteOneTicketAsync (int id, bool trackChanges);
    Task<(TicketDto ticketDto, Ticket ticket)> GetOneTicketForPatchAsync (int id, bool trackChanges);
    Task SaveChangesForPatchAsync (TicketDto ticketDto, Ticket ticket);
}