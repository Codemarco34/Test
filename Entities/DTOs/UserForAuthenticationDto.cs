using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public record UserForAuthenticationDto
{
    [Required(ErrorMessage = "UserName Is Required")]
    public string? UserName { get; init; }
    [Required(ErrorMessage = "Password Is Required")]
    public string? Password { get; init; }
    
}