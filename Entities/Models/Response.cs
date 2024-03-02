namespace Entities.Models;

public class Response 
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }
    // Diğer özellikler

    public int UserId { get; set; }  // Cevabı veren kullanıcının ID'si
    public User User { get; set; }    // Cevabı veren kullanıcı

    public int TicketId { get; set; }  // Cevap verilen ticket'ın ID'si
    public Ticket Ticket { get; set; }  // Cevap verilen ticket
    
}