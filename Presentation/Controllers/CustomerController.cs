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
            try
            {
                var Customers = _manager.CustomerService.GetAllCustomer(false);
                return Ok(Customers);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneCustomer([FromRoute(Name = "id")] int id)
        {
            try
            {
                var Customers = _manager.CustomerService.GetOneCustomerById(id, false);
                if (Customers is null)
                    return NotFound();
                return Ok(Customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            

        }

        [HttpPost]
        public IActionResult CreateOneCustomer([FromBody]Customer customer)
        {
            try
            {
                if (customer is null)
                    return NotFound();
                _manager.CustomerService.CreateOneCustomer(customer);
                return StatusCode(201, customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneCustomer([FromRoute(Name = "id")]int id, [FromBody] Customer customer)
        {
            try
            {
                
                if (customer is null)
                    return NotFound();
                _manager.CustomerService.UpdateOneCustomer(id,customer,true);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneCustomer([FromRoute(Name = "id")]int id)
        {
            try
            {
                
                _manager.CustomerService.DeleteOneCustomer(id, false);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneCustomer([FromRoute(Name = "id")]int id ,[FromBody] JsonPatchDocument<Customer>customerPatch)
        {

            try
            {
                var entity = _manager.CustomerService.GetOneCustomerById(id, true);
                if (entity is null)
                    return BadRequest($"Customer with id{id} not found");
                customerPatch.ApplyTo(entity);
                _manager.CustomerService.UpdateOneCustomer(id,entity,true);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }

    }