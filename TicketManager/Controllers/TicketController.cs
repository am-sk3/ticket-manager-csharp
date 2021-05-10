using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Extensions;
using TicketManager.Repository.Models;
using TicketManager.Services;
using TicketManager.ViewModels.Comment;
using TicketManager.ViewModels.Ticket;

namespace TicketManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly ICommentService _commentService;

        public TicketController(ITicketService ticketService, ICommentService commentService)
        {
            _ticketService = ticketService;
            _commentService = commentService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TicketGetAllViewModel>>> GetAll()
        {
            var result = await _ticketService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TicketGetViewModel>> GetByID(int id)
        {
            var result = await _ticketService.GetByIdAsync(id);

            if (result is null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(TicketAddViewModel ticket)
        {
            var result = await _ticketService.CreateAsync(ticket);

            return CreatedAtAction(nameof(GetByID), new { id = result }, ticket);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, TicketStatus status)
        {
            var result = await _ticketService.ChangeStatusAsync(status, id);

            if (result.NotEquals(1))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ticketService.RemoveAsync(id);

            if (result.NotEquals(1))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id}/comments")]
        public async Task<ActionResult<IEnumerable<CommentGetViewModel>>> GetComments(int id)
        {
            var result = await _commentService.GetAllAsync(id);

            return Ok(result);
        }

    }
}
