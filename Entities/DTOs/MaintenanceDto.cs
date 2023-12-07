namespace Entities.DTOs;

public record MaintenanceDto(
    DateTime FinishDate, 
    DateTime StartDate, 
    string ServicePeriod,
    int ServiceTime, 
    string Explanation, 
    int Id, 
    string DealType, 
    string Customer,
    bool IsActive, 
    int TaxNumber);
