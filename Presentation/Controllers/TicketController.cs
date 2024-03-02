using Entities.DTOs;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentation.ActionFilters;
using Services.Contracts;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace Presentation.Controllers;
[ServiceFilter(typeof(LogFilterAttribute))] 
[ApiController]
[Route("api/Ticket")]
public class TicketController : ControllerBase
{
    
    private readonly IServiceManager _manager;

    public TicketController(IServiceManager manager)
    {
        _manager = manager;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetAllTicket([FromQuery]TicketParameters ticketParameters)
    {
        var pagedResult = await _manager
            .TicketService
            .GetAllTicketAsync(ticketParameters,false);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        
        
        return Ok(pagedResult.ticket);
        
    }
    
    [HttpGet("{id:int}")]
    public async Task <IActionResult> GetOneTicket([FromRoute(Name = "id")] int id)
    {
        var tickets = await _manager.TicketService.GetOneTicketByIdAsync(id, false);
        return Ok(tickets);
    }
    
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [HttpPost]
    public async Task<IActionResult> CreateOneTicket([FromBody]TicketDtoForInsertion ticketDto)
    { 
        if (ticketDto is null)
            return NotFound();
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        var ticket= await _manager.TicketService.CreateOneTicketAsync(ticketDto);
        return StatusCode(201, ticket);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateOneTicket([FromRoute(Name = "id")]int id, [FromBody] TicketDto ticketDto)
    {
        if (ticketDto is null)
            return NotFound();

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
                
        await _manager.TicketService.UpdateOneTicketAsync(id,ticketDto,false);
        return NoContent();

    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteOneTicket([FromRoute(Name = "id")]int id)
    {
        await _manager.TicketService.DeleteOneTicketAsync(id, false);
        return NoContent();
    }
    
    
    [HttpPatch("{id:int}")]
    public async Task<IActionResult> PartiallyUpdateOneTicket([FromRoute(Name = "id")]int id ,[FromBody] JsonPatchDocument<TicketDto>ticketPatch)
    {
        if (ticketPatch is null)
            return BadRequest(); //400 

        var result = await _manager.TicketService.GetOneTicketForPatchAsync(id, false);
        ticketPatch.ApplyTo(result.ticketDto, ModelState);
        TryValidateModel(result.ticketDto);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);
        await _manager.TicketService.SaveChangesForPatchAsync(result.ticketDto,result.ticket);
        return NoContent();


    }
    
    
}