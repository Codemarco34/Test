using Entities.DTOs;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts;

public interface IMaintenanceService
{
    Task<(IEnumerable<MaintenanceDto> maintenances, MetaData metaData)> GetAllMaintenanceAsync (MaintenanceParameters maintenanceParameters,bool trackChanges);
    Task<MaintenanceDto> GetMaintenanceByIdAsync (int id, bool trackChanges);
    Task<MaintenanceDto> CreateOneMaintenanceAsync (MaintenanceDtoForInsertion maintenance);
    Task UpdateOneMaintenanceAsync (int id,MaintenanceDto maintenanceDto ,bool trackChanges);
    Task  DeleteOneMaintenanceAsync (int id, bool trackChanges);
    Task<(MaintenanceDto maintenanceDto, Maintenance maintenance)> GetOneMaintenanceForPatchAsync (int id, bool trackChanges);
    Task SaveChangesForPatchAsync (MaintenanceDto maintenanceDto, Maintenance maintenance);
}