using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Extensions;
using TicketManager.Services;
using TicketManager.ViewModels.Ticket;
using TicketManager.ViewModels.User;
using TicketManager.ViewModels.UserCompany;

namespace TicketManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ITicketService _ticketService;
        private readonly IUserCompaniesService _userCompaniesService;

        public UserController(IUserService userService, ITicketService ticketService, IUserCompaniesService userCompaniesService)
        {
            _service = userService;
            _ticketService = ticketService;
            _userCompaniesService = userCompaniesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserGetViewModel>>> GetAllUsers(bool onlyEnabled)
        {
            var users = await _service.GetAllAsync();

            return Ok(new { users });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserGetViewModel>> GetUser(int id)
        {
            var user = await _service.GetByIdAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(UserAddEditViewModel company)
        {
            var result = await _service.CreateAsync(company);

            return CreatedAtAction(nameof(GetUser), new { id = result }, company);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EditUser(int id, UserAddEditViewModel user)
        {
            var result = await _service.EditAsync(user, id);

            if (result.NotEquals(1))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var result = await _service.RemoveAsync(id);

            if (result.Equals(0))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id}/tickets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TicketGetAllViewModel>>> GetTicketsByUser(int id)
        {
            var result = await _ticketService.GetByUser(id);

            return Ok(result);
        }

        [HttpGet("{id}/companies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CompanyUserGetViewModel>>> GetUserCompanies(int id)
        {
            var result = await _userCompaniesService.GetAllCompaniesFromUserID(id);

            return Ok(result);
        }

        [HttpPost("{id}/companies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> AddCompanyToUser(int id, UserCompanyAddViewModel company)
        {
            var result = await _userCompaniesService.AddCompanyToUser(id, company);

            return Ok(result);
        }

        [HttpDelete("{id}/companies/{companyID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RemoveCompanyFromUser(int id, int companyID)
        {
            var result = await _userCompaniesService.RemoveUserFromCompany(id, companyID);

            if (result.Equals(0))
                return NotFound();

            return NoContent();
        }

    }
}
