using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Extensions;
using TicketManager.Repository.Models;
using TicketManager.Services;
using TicketManager.ViewModels.Company;

namespace TicketManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CompanyGetViewModel>>> GetAllCompanies(bool onlyEnabled)
        {
            var companies = await _service.GetAllAsync(onlyEnabled);

            return Ok(new { companies });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CompanyGetViewModel>> GetCompany(int id)
        {
            var company = await _service.GetByIDAsync(id);

            if (company is null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCompany(CompanyAddEditViewModel company)
        {
            var result = await _service.CreateAsync(company);

            return CreatedAtAction(nameof(GetCompany), new { id = result },company);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EditCompany(int id, CompanyAddEditViewModel company)
        {
            var result = await _service.EditAsync(company, id);

            if (result.NotEquals(1))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var result = await _service.RemoveAsync(id);

            if (result.Equals(0))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
