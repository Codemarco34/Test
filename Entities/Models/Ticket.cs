using Entities.DTOs;

namespace Entities.Models;

public class Ticket 
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsActive { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public List<Response> Responses { get; set; }
    
}