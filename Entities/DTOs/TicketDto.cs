using Entities.Models;

namespace Entities.DTOs;

public record TicketDto : TicketDtoForManipulation
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public int UserId { get; set; }
    public UserDto User { get; set; }
    public List<ResponseDto> Responses { get; set; }
}