using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore;

public class MaintenanceRepository : RepositoryBase<Maintenance> , IMaintenanceRepository
{
    public MaintenanceRepository(RepositoryContext context) : base(context)
    {
    }

    public IQueryable<Maintenance> GetAllMaintenance(bool trackChanges) =>
        FindAll(trackChanges).OrderBy(m => m.Id);

    public Maintenance GetOneMaintenanceById(int id, bool trackChanges) =>
        FindByCondition(m => m.Id.Equals(id), trackChanges).SingleOrDefault();


    public void CreateOneMaintenance(Maintenance maintenance) => Create(maintenance);


    public void UpdateOneMaintenance(Maintenance maintenance) => Update(maintenance);


    public void DeleteOneMaintenance(Maintenance maintenance) => Delete(maintenance);

}