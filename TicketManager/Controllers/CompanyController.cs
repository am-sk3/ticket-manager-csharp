using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Entities;
using TicketManager.Extensions;
using TicketManager.Models;
using TicketManager.Services;

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
        public async Task<ActionResult> GetAllCompanies(bool onlyEnabled)
        {
            var companies = await _service.GetAllAsync(onlyEnabled);

            return Ok(new { companies });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCompany(int id)
        {
            var company = await _service.GetByIDAsync(id);

            if (company is null)
            {
                return NotFound();
            }

            return Ok(new { company });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> CreateCompany(CompanyClient company)
        {
            var result = await _service.CreateAsync(company.Name);

            return CreatedAtAction(nameof(GetCompany), new { id = result },company);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> EditCompany(int id, CompanyClient company)
        {
            var result = await _service.EditAsync(company, id);

            if (result.NotEquals(1))
            {
                throw new Exception("failed to edit");
            }
            return NoContent();
        }
    }
}
