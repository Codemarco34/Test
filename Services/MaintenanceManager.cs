using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class MaintenanceManager : IMaintenanceService
{
    private readonly IRepositoryManager _manager;

    public MaintenanceManager(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public IEnumerable<Maintenance> GetAllMaintenance(bool trackChanges)
    {
        return _manager.Maintenance.GetAllMaintenance(trackChanges);
    }

    public Maintenance GetMaintenanceById(int id, bool trackChanges)
    {
        return _manager.Maintenance.GetOneMaintenanceById(id, trackChanges);
    }

    public Maintenance CreateOneMaintenance(Maintenance maintenance)
    {
        if (maintenance is null)
            throw new ArgumentNullException(nameof(maintenance));
        _manager.Maintenance.CreateOneMaintenance(maintenance);
        _manager.Save();
        return maintenance;
    }

    public void UpdateOneMaintenance(int id, Maintenance maintenance, bool trackChanges)
    {
        var entity = _manager.Maintenance.GetOneMaintenanceById(id, trackChanges);
        if (entity is null)
            throw new Exception($"Maintenance with id {id} could not found");
        if (maintenance is null)
            throw new ArgumentNullException(nameof(maintenance));

        entity.Customer = maintenance.Customer;
        entity.Explanation = maintenance.Explanation;
        entity.IsActive = maintenance.IsActive;
        entity.DealType = maintenance.DealType;
        entity.FinishDate = maintenance.FinishDate;
        entity.ServicePeriod = maintenance.ServicePeriod;
        entity.ServiceTime = maintenance.ServiceTime;
        entity.StartDate = maintenance.StartDate;
        entity.TaxNumber = maintenance.TaxNumber;
        _manager.Maintenance.Update(entity);
        _manager.Save();
    }

    

    public void DeleteOneMaintenance(int id, bool trackChanges)
    {
        var entity = _manager.Maintenance.GetOneMaintenanceById(id, trackChanges);
        if (entity is null)
            throw new Exception($"Maintenance with id : {id} could not found");
        _manager.Maintenance.DeleteOneMaintenance(entity);
        _manager.Save();

    }
}