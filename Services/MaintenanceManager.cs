using AutoMapper;
using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
using NLog;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class MaintenanceManager : IMaintenanceService
{
    private readonly IRepositoryManager _manager;
    private readonly  ILoggerService _logger;
    private readonly IMapper _mapper;

    public MaintenanceManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
    {
        _manager = manager;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<Maintenance> GetAllMaintenance(bool trackChanges)
    {
        return _manager.Maintenance.GetAllMaintenance(trackChanges);
    }

    public Maintenance GetMaintenanceById(int id, bool trackChanges)
    {
        var maintenance =  _manager.Maintenance.GetOneMaintenanceById(id, trackChanges);
        if (maintenance is null)
            throw new MaintenanceNotFoundException(id);
        return maintenance;
    }

    public Maintenance CreateOneMaintenance(Maintenance maintenance)
    {

        string msg = "Maintenance Created";
        _logger.LogInfo(msg);
        _manager.Maintenance.CreateOneMaintenance(maintenance);
        _manager.Save();
        return maintenance;
    }

    public void UpdateOneMaintenance(int id, MaintenanceDto maintenanceDto, bool trackChanges)
    {
        var entity = _manager.Maintenance.GetOneMaintenanceById(id, trackChanges);
        if (entity is null)
            throw new MaintenanceNotFoundException(id);

        entity = _mapper.Map<Maintenance>(maintenanceDto);
        _manager.Maintenance.Update(entity);
        _manager.Save();
    }

    

    public void DeleteOneMaintenance(int id, bool trackChanges)
    {
        var entity = _manager.Maintenance.GetOneMaintenanceById(id, trackChanges);
        if (entity is null)
            throw new MaintenanceNotFoundException(id);
            
        _manager.Maintenance.DeleteOneMaintenance(entity);
        _manager.Save();

    }
}