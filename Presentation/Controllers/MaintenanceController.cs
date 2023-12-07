using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers;
[ApiController]
[Route("api/Maintenance")]
public class MaintenanceController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public MaintenanceController(IServiceManager manager)
        {
            _manager = manager;
        }


        [HttpGet]
        public IActionResult GelAllMaintenance()
        {
                var Maintenances = _manager.MaintenanceService.GetAllMaintenance(false);
                return Ok(Maintenances);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneMaintenance([FromRoute(Name = "id")] int id)
        {
                var Maintenance = _manager.MaintenanceService.GetMaintenanceById(id, false);
                return Ok(Maintenance);
            

        }

        [HttpPost]
        public IActionResult CreateOneMaintenance([FromBody]Maintenance maintenance)
        {if (maintenance is null)
                    return NotFound();
                _manager.MaintenanceService.CreateOneMaintenance(maintenance);
                return StatusCode(201, maintenance);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneMaintenance([FromRoute(Name = "id")]int id, [FromBody] MaintenanceDto maintenanceDto)
        {
                if (maintenanceDto is null)
                    return NotFound();
                
                _manager.MaintenanceService.UpdateOneMaintenance(id,maintenanceDto,true);
                
                return NoContent();
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneMaintenance([FromRoute(Name = "id")]int id)
        {
                _manager.MaintenanceService.DeleteOneMaintenance(id,false);
                return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneMaintenance([FromRoute(Name = "id")]int id ,[FromBody] JsonPatchDocument<Maintenance> maintenancePatch)
        {
                var entity = _manager.MaintenanceService.GetMaintenanceById(id, false);
                maintenancePatch.ApplyTo(entity);
                _manager.MaintenanceService.UpdateOneMaintenance(id,
                    new MaintenanceDto(
                        entity.FinishDate, entity.StartDate, entity.ServicePeriod, entity.ServiceTime, entity.Explanation, entity.Id, entity.DealType, entity.Customer, entity.IsActive ,entity.TaxNumber
                        ),true);
                return NoContent();
        }

    }