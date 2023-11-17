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
            try
            {
                var Maintenances = _manager.MaintenanceService.GetAllMaintenance(false);
                return Ok(Maintenances);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneMaintenance([FromRoute(Name = "id")] int id)
        {
            try
            {
                var Maintenance = _manager.MaintenanceService.GetMaintenanceById(id, false);
                if (Maintenance is null)
                    return NotFound();
                return Ok(Maintenance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            

        }

        [HttpPost]
        public IActionResult CreateOneMaintenance([FromBody]Maintenance maintenance)
        {
            try
            {
                if (maintenance is null)
                    return NotFound();
                _manager.MaintenanceService.CreateOneMaintenance(maintenance);
                return StatusCode(201, maintenance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneMaintenance([FromRoute(Name = "id")]int id, [FromBody] Maintenance maintenance)
        {
            try
            {
                
                if (maintenance is null)
                    return NotFound();
                
                _manager.MaintenanceService.UpdateOneMaintenance(id,maintenance,true);
                
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneMaintenance([FromRoute(Name = "id")]int id)
        {
            try
            {
                _manager.MaintenanceService.DeleteOneMaintenance(id,false);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneMaintenance([FromRoute(Name = "id")]int id ,[FromBody] JsonPatchDocument<Maintenance> maintenancePatch)
        {
            try
            {
                var entity = _manager.MaintenanceService.GetMaintenanceById(id, false);
                if (entity is null)
                    return BadRequest($"Meintenance with id{id} not found");
                maintenancePatch.ApplyTo(entity);
                _manager.MaintenanceService.UpdateOneMaintenance(id,entity,true);
                return NoContent();


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }