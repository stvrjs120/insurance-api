using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceAPI.Models;
using InsuranceAPI.Models.Context;
using InsuranceAPI.Interfaces;
using InsuranceAPI.ViewModels;

namespace InsuranceAPI.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerMap customerMap;

        public CustomersController(ICustomerMap map)
        {
            customerMap = map;
        }

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<CustomerViewModel> GetCustomers()
        {
            return customerMap.List();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public CustomerViewModel GetCustomer([FromRoute] int id)
        {
            return customerMap.Read(id);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public IActionResult PutCustomer([FromRoute] int id, [FromBody] CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.id)
            {
                return BadRequest();
            }

            bool result = false;

            try
            {
                result = customerMap.Update(customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!result)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        [HttpPost]
        public IActionResult PostCustomer([FromBody] CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            customerMap.Create(customer);

            return CreatedAtAction("GetCustomer", new { customer.id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = customerMap.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }


    }
}