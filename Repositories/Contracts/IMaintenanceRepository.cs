using Entities.DTOs;
using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts;

public interface IMaintenanceRepository : IRepositoryBase<Maintenance>
{
    Task<PagedList<Maintenance>> GetAllMaintenanceAsync (MaintenanceParameters parameters,bool trackChanges);
    Task<Maintenance> GetOneMaintenanceByIdAsync (int id ,bool trackChanges);
    void CreateOneMaintenance(Maintenance maintenance);
    void UpdateOneMaintenance(Maintenance maintenance);
    void DeleteOneMaintenance(Maintenance maintenance);
}