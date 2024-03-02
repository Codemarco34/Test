using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class TicketManager : ITicketService
{
    private readonly IRepositoryManager _manager;
    private readonly  ILoggerService _logger;
    private readonly IMapper _mapper;
    
    public TicketManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
    {
        _manager = manager;
        _logger = logger;
        _mapper = mapper;
    }
    public async Task<(IEnumerable<TicketDto> ticket, MetaData metaData)> GetAllTicketAsync (TicketParameters ticketParameters,bool trackChanges)
    {
        var ticketwithMetadata = await _manager
            .Ticket
            .GetAllTicketsAsync(ticketParameters,trackChanges);
        var ticketsDto = _mapper.Map<IEnumerable<TicketDto>>(ticketwithMetadata);
        return (ticketsDto, ticketwithMetadata.MetaData);
    }
    
    public async Task<TicketDto> GetOneTicketByIdAsync(int id, bool trackChanges)
    {
        var ticket = await GetOneTicketByIdCheckExists(id, trackChanges);
        return _mapper.Map<TicketDto>(ticket);
    }

    public async Task<TicketDto> CreateOneTicketAsync(TicketDtoForInsertion ticketDto)
    {
        var entity = _mapper.Map<Ticket>(ticketDto);
        _manager.Ticket.CreateOneTicket(entity);
        await _manager.SaveAsync();
        return _mapper.Map<TicketDto>(entity);
    }

   
    public async Task UpdateOneTicketAsync(int id, TicketDto ticketDto, bool trackChanges)
    {
        var entity = await GetOneTicketByIdCheckExists(id, trackChanges);

        entity = _mapper.Map<Ticket>(ticketDto);
        _manager.Ticket.Update(entity);
        await _manager.SaveAsync();
    }
    
    public async Task DeleteOneTicketAsync (int id, bool trackChanges)
    {

        var entity = await GetOneTicketByIdCheckExists(id, trackChanges);
        _manager.Ticket.DeleteOneTicket(entity);
        await _manager.SaveAsync();

    }
    public async Task<(TicketDto ticketDto, Ticket ticket)> GetOneTicketForPatchAsync (int id, bool trackChanges)
    {
        var ticket = await GetOneTicketByIdCheckExists(id,trackChanges);
        var TicketDtoForUpdate = _mapper.Map<TicketDto>(ticket);
        return (TicketDtoForUpdate, ticket);
    }
    public async Task SaveChangesForPatchAsync (TicketDto ticketDto, Ticket ticket)
    {
        _mapper.Map(ticketDto, ticket);
        await _manager.SaveAsync();
    }
    
    private async Task<Ticket> GetOneTicketByIdCheckExists(int id, bool trackChanges)
    {
        var entity = await _manager.Ticket.GetOneTicketByIdAsync (id, trackChanges);
        return entity;
    }
}