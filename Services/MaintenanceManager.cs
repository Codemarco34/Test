using AutoMapper;
using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
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

    public async Task<(IEnumerable<MaintenanceDto> maintenances, MetaData metaData)> GetAllMaintenanceAsync (MaintenanceParameters maintenanceParameters,bool trackChanges)
    {
        var maintenancewithMetadata = await _manager
            .Maintenance
            .GetAllMaintenanceAsync(maintenanceParameters,trackChanges);
         var maintenancesDto = _mapper.Map<IEnumerable<MaintenanceDto>>(maintenancewithMetadata);
         return (maintenancesDto, maintenancewithMetadata.MetaData);
    }

    public async Task<MaintenanceDto> GetMaintenanceByIdAsync(int id, bool trackChanges)
    {
        var maintenance = await  _manager.Maintenance.GetOneMaintenanceByIdAsync(id, trackChanges);
        if (maintenance is null)
            throw new MaintenanceNotFoundException(id);
        return _mapper.Map<MaintenanceDto>(maintenance);
    }

    public async Task<MaintenanceDto> CreateOneMaintenanceAsync (MaintenanceDtoForInsertion maintenanceDto)
    {
        // string msg = "Maintenance Created";
        // _logger.LogInfo(msg);
        var entity = _mapper.Map<Maintenance>(maintenanceDto);
        _manager.Maintenance.CreateOneMaintenance(entity);
        await _manager.SaveAsync();
        return _mapper.Map<MaintenanceDto>(entity);
    }

    public async Task UpdateOneMaintenanceAsync (int id, MaintenanceDto maintenanceDto, bool trackChanges)
    {
        var entity = await _manager.Maintenance.GetOneMaintenanceByIdAsync(id, trackChanges);
        if (entity is null)
            throw new MaintenanceNotFoundException(id);

        entity = _mapper.Map<Maintenance>(maintenanceDto);
        _manager.Maintenance.Update(entity);
        await _manager.SaveAsync();
    }

    public async Task DeleteOneMaintenanceAsync (int id, bool trackChanges)
    {
        var entity = await _manager.Maintenance.GetOneMaintenanceByIdAsync(id, trackChanges);
        if (entity is null)
            throw new MaintenanceNotFoundException(id);
            
        _manager.Maintenance.DeleteOneMaintenance(entity);
        await _manager.SaveAsync();

    }

    public async Task<(MaintenanceDto maintenanceDto, Maintenance maintenance)> GetOneMaintenanceForPatchAsync (int id, bool trackChanges)
    {
        var maintenance = await _manager.Maintenance.GetOneMaintenanceByIdAsync(id, trackChanges);
        if (maintenance is null)
            throw new MaintenanceNotFoundException(id);
        var MaintenanceDtoForUpdate = _mapper.Map<MaintenanceDto>(maintenance);
        return (MaintenanceDtoForUpdate, maintenance);
    }

    public async Task SaveChangesForPatchAsync (MaintenanceDto maintenanceDto, Maintenance maintenance)
    {
        _mapper.Map(maintenanceDto, maintenance);
        await _manager.SaveAsync();
    }
}