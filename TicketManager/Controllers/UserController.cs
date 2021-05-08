using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Extensions;
using TicketManager.Services;
using TicketManager.ViewModels.User;

namespace TicketManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService userService)
        {
            _service = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserGetViewModel>>> GetAllUsers(bool onlyEnabled)
        {
            var users= await _service.GetAllAsync();

            return Ok(new { users });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserGetViewModel>> GetUser(int id)
        {
            var user= await _service.GetByIdAsync(id);

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
    }
}
