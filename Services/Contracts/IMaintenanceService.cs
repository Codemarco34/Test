using Entities.Models;

namespace Services.Contracts;

public interface IMaintenanceService
{
    IEnumerable<Maintenance> GetAllMaintenance(bool trackChanges);
    Maintenance GetMaintenanceById(int id, bool trackChanges);
    Maintenance CreateOneMaintenance(Maintenance meMaintenance);
    void UpdateOneMaintenance(int id,Maintenance maintenance ,bool trackChanges);
    void DeleteOneMaintenance(int id, bool trackChanges);

}