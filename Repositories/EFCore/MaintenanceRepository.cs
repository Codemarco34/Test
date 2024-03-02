using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore;

public class MaintenanceRepository : RepositoryBase<Maintenance> , IMaintenanceRepository
{
    public MaintenanceRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<PagedList<Maintenance>> GetAllMaintenanceAsync(MaintenanceParameters maintenanceParameters,
        bool trackChanges)
    {
        var maintenance = await FindAll(trackChanges)
            .OrderBy(m => m.Id)
            .ToListAsync();
        return PagedList<Maintenance>
            .ToPagedList(maintenance, maintenanceParameters.PageNumber, maintenanceParameters.PageSize);

    }
        



    public async  Task<Maintenance> GetOneMaintenanceByIdAsync (int id, bool trackChanges) =>
       await  FindByCondition(m => m.Id.Equals(id), trackChanges).
            SingleOrDefaultAsync();


    public void CreateOneMaintenance(Maintenance maintenance) => Create(maintenance);


    public void UpdateOneMaintenance(Maintenance maintenance) => Update(maintenance);


    public void DeleteOneMaintenance(Maintenance maintenance) => Delete(maintenance);

}