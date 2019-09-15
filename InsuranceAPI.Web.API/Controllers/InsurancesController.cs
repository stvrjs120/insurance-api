using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InsuranceAPI.Models;
using InsuranceAPI.Interfaces;
using InsuranceAPI.ViewModels;

namespace InsuranceAPI.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancesController : ControllerBase
    {
        private readonly IInsuranceMap insuranceMap;

        public InsurancesController(IInsuranceMap map)
        {
            insuranceMap = map;
        }

        // GET: api/Insurances
        [HttpGet]
        public IEnumerable<InsuranceViewModel> GetInsurances()
        {
            return insuranceMap.List();
        }

        // GET: api/Insurances/5
        [HttpGet("{id}")]
        public IActionResult GetInsurance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var insurance = insuranceMap.Read(id);

            if (insurance == null)
            {
                return NotFound();
            }

            return Ok(insurance);
        }

        // PUT: api/Insurances/5
        [HttpPut("{id}")]
        public IActionResult PutInsurance([FromRoute] int id, [FromBody] InsuranceViewModel insurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != insurance.id)
            {
                return BadRequest();
            }

            bool result = false;

            try
            {
                result = insuranceMap.Update(insurance);
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

        // POST: api/Insurances
        [HttpPost]
        public IActionResult PostInsurance([FromBody] InsuranceViewModel insurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            insuranceMap.Create(insurance);

            return CreatedAtAction("GetInsurance", new { insurance.id }, insurance);
        }

        // DELETE: api/Insurances/5
        [HttpDelete("{id}")]
        public IActionResult DeleteInsurance([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = insuranceMap.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}