namespace Entities.Exceptions;

public sealed class TicketNotFoundExeption : NotFoundException
{
    public TicketNotFoundExeption(int id) : base($"The Ticket id:{id} could not found")
    {
    }
}