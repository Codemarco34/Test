using Entities.DTOs;
using Entities.Models;

namespace Repositories.Contracts;

public interface IMaintenanceRepository : IRepositoryBase<Maintenance>
{
    IQueryable<Maintenance> GetAllMaintenance(bool trackChanges);
    Maintenance GetOneMaintenanceById(int id ,bool trackChanges);
    void CreateOneMaintenance(Maintenance maintenance);
    void UpdateOneMaintenance(Maintenance maintenance);
    void DeleteOneMaintenance(Maintenance maintenance);
}