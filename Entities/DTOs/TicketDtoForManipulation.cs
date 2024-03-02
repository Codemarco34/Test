using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.DTOs;

public abstract record TicketDtoForManipulation
{

    public int Id { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    // Diğer özellikler
    public int UserId { get; set; }  // Ticket'ı oluşturan kullanıcının ID'si
    public UserDto User { get; set; }    // Ticket'ı oluşturan kullanıcı
    public List<ResponseDto> Responses { get; set; } // Cevap verilen ticket
    
}