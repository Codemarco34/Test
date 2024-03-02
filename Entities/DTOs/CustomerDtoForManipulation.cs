using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public abstract record CustomerDtoForManipulation
{
    //[MinLength(3,ErrorMessage = "title least be 3 character")]// title alanı kontrol ediliyor.
    public string Title { get; init; }
    public int Id { get; init; }
    [Required(ErrorMessage = "CustomerCode is required field")]
    public string? CustomerCode { get; init; }
    //[Range(0,100,ErrorMessage = "CustomerTaxNumber cannot be longer than 100 characters")]
    [Required]
    public int CustomerTaxNumber { get; init; }
    public int MainCurrentCode { get; init; }
    public string? Adress { get; init; }
    public string? ProductGroup { get; init; }
    public string? Version { get; init; }
    public string? Modul { get; init; }
    public string? Esolutions { get; init; }
    public DateTime MaintenanceDate { get; init; }
    public bool Active { get; init; }
}