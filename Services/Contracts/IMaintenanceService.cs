using Entities.DTOs;
using Entities.Models;

namespace Services.Contracts;

public interface IMaintenanceService
{
    IEnumerable<Maintenance> GetAllMaintenance(bool trackChanges);
    Maintenance GetMaintenanceById(int id, bool trackChanges);
    Maintenance CreateOneMaintenance(Maintenance maintenance);
    void UpdateOneMaintenance(int id,MaintenanceDto maintenanceDto ,bool trackChanges);
    void DeleteOneMaintenance(int id, bool trackChanges);

}