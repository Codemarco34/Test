
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers;
[ApiController]
[Route("api/Customer")]
public class CustomerController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CustomerController(IServiceManager manager)
        {
            _manager = manager;
            
        }


        [HttpGet]
        public IActionResult GelAllCustomer()
        {
                var customers = _manager.CustomerService.GetAllCustomer(false);
                return Ok(customers);
           
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneCustomer([FromRoute(Name = "id")] int id)
        {
                var customers = _manager.CustomerService.GetOneCustomerById(id, false);
                return Ok(customers);
        }

        
        [HttpPost]
        public IActionResult CreateOneCustomer([FromBody]Customer customer)
        {
                if (customer is null)
                    return NotFound();
                _manager.CustomerService.CreateOneCustomer(customer);
                return StatusCode(201, customer);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneCustomer([FromRoute(Name = "id")]int id, [FromBody] CustomerDto customerDto)
        {
                if (customerDto is null)
                    return NotFound();
                _manager.CustomerService.UpdateOneCustomer(id,customerDto,true);
                return NoContent();

        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneCustomer([FromRoute(Name = "id")]int id)
        {
                _manager.CustomerService.DeleteOneCustomer(id, false);
                return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneCustomer([FromRoute(Name = "id")]int id ,[FromBody] JsonPatchDocument<Customer>customerPatch)
        {
                var entity = _manager.CustomerService.GetOneCustomerById(id, true);
                customerPatch.ApplyTo(entity);
                _manager.CustomerService.UpdateOneCustomer(id, 
                    new CustomerDto(),true);
                return NoContent();

        }

    }