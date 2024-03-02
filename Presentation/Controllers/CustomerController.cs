
using System.Text.Json;
using Entities.DTOs;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers;


[Authorize]
[ServiceFilter(typeof(LogFilterAttribute))] // En üstte olması bütün metotları lodluyabiliriz !! 
[ApiController]
[Route("api/Customer")]
public class CustomerController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CustomerController(IServiceManager manager)
        {
            _manager = manager;
            
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer([FromQuery]CustomerParameters customerParameters)
        {
                var pagedResult = await _manager
                    .CustomerService
                    .GetAllCustomerAsync(customerParameters,false);
                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
                return Ok(pagedResult.customer);
           
        }

        [HttpGet("{id:int}")]
        public async Task <IActionResult> GetOneCustomer([FromRoute(Name = "id")] int id)
        {
                var customers = await _manager.CustomerService.GetOneCustomerByIdAsync(id, false);
                return Ok(customers);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneCustomer([FromBody]CustomerDtoForInsertion customerDto)
        { 
                var customer = await _manager.CustomerService.CreateOneCustomerAsync(customerDto);
                return StatusCode(201, customer);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneCustomer([FromRoute(Name = "id")]int id, [FromBody] CustomerDto customerDto)
        {
                if (customerDto is null)
                    return NotFound();

                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);
                
                await _manager.CustomerService.UpdateOneCustomerAsync(id,customerDto,false);
                return NoContent();

        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneCustomer([FromRoute(Name = "id")]int id)
        {
                await _manager.CustomerService.DeleteOneCustomerAsync(id, false);
                return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateOneCustomer([FromRoute(Name = "id")]int id ,[FromBody] JsonPatchDocument<CustomerDto>customerPatch)
        {
            if (customerPatch is null)
                return BadRequest(); //400 

            var result = await _manager.CustomerService.GetOneCustomerForPatchAsync(id, false);
                customerPatch.ApplyTo(result.customerDto, ModelState);
                TryValidateModel(result.customerDto);

                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);
                await _manager.CustomerService.SaveChangesForPatchAsync(result.customerDto,result.customer);
                return NoContent();


        }

    }