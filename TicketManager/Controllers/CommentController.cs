using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Extensions;
using TicketManager.Services;
using TicketManager.ViewModels.Comment;

namespace TicketManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CommentGetViewModel>> GetByID(int id)
        {
            var result = await _commentService.GetByID(id);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CommentAddEditViewModel comment)
        {
            var result = await _commentService.CreateAsync(comment);

            return CreatedAtAction(nameof(GetByID), new { id = result }, comment);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _commentService.RemoveAsync(id);

            if (result.NotEquals(1))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
