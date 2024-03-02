namespace Entities.DTOs;

public class ResponseDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }

    public int UserId { get; set; }
    public UserDto User { get; set; }
}