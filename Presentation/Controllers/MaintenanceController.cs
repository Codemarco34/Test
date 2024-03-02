using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Presentation.ActionFilters;
using Services.Contracts;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Presentation.Controllers;
[ServiceFilter(typeof(LogFilterAttribute))] 
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
        public async Task<IActionResult> GelAllMaintenance([FromQuery]MaintenanceParameters maintenanceParameters)
        {
                var pagedResult = await _manager
                    .MaintenanceService
                    .GetAllMaintenanceAsync(maintenanceParameters,false);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
                return Ok(pagedResult.maintenances);
        }
        

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneMaintenance([FromRoute(Name = "id")] int id)
        {
                var maintenance = await _manager.MaintenanceService.GetMaintenanceByIdAsync(id, false);
                return Ok(maintenance);
            

        }
        
        
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public  async Task<IActionResult> CreateOneMaintenance([FromBody]MaintenanceDtoForInsertion maintenanceDto)
        {
            if (maintenanceDto is null)
                    return NotFound();
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var maintenance= await _manager.MaintenanceService.CreateOneMaintenanceAsync(maintenanceDto);
            return StatusCode(201, maintenance);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneMaintenance([FromRoute(Name = "id")]int id, [FromBody] MaintenanceDto maintenanceDto)
        {
                if (maintenanceDto is null)
                    return NotFound();
                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);
                
                await _manager.MaintenanceService.UpdateOneMaintenanceAsync(id,maintenanceDto,false);
                
                return NoContent();
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneMaintenance([FromRoute(Name = "id")]int id)
        {
                await _manager.MaintenanceService.DeleteOneMaintenanceAsync(id,false);
                return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateOneMaintenance([FromRoute(Name = "id")]int id ,[FromBody] JsonPatchDocument<MaintenanceDto> maintenancePatch)
        {
            if (maintenancePatch is null)
                return BadRequest();

            var result = await _manager.MaintenanceService.GetOneMaintenanceForPatchAsync(id, false);
            
                maintenancePatch.ApplyTo(result.maintenanceDto,ModelState);
                TryValidateModel(result.maintenanceDto);
                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);
                
                await _manager.MaintenanceService.SaveChangesForPatchAsync(result.maintenanceDto,result.maintenance);
                return NoContent();
        }

    }