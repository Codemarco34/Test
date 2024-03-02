using System.Runtime.InteropServices.JavaScript;

namespace Entities.DTOs;

public record MaintenanceDto : MaintenanceDtoForManipulation
{
    
    
    public int Id { get; set; }
    public string Customer { get; set; }
    public DateTime FinishDate { get; set; }
    public DateTime StartDate { get; set; }
    public string ServicePeriod { get; set; }
    public int ServiceTime { get; set; }
    public string Explanation { get; set; }
    public string DealType { get; set; }
    public bool IsActive { get; set; }
    public int TaxNumber { get; set; }
    
   
}

