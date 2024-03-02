using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs;

public abstract record MaintenanceDtoForManipulation
{
    [Required(ErrorMessage = "Customer is required field")]
    [MinLength(3)]
    [MaxLength(15,ErrorMessage = "Cannot be more 15 character")]
    public string Customer { get; init; }
    public int Id { get; set; }
    public DateTime FinishDate { get; set; }
    public DateTime StartDate { get; set; }
    public string ServicePeriod { get; set; }
    public int ServiceTime { get; set; }
    public string Explanation { get; set; }
    public string DealType { get; set; }
    public bool IsActive { get; set; }
    public int TaxNumber { get; set; }
}