using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Extensions;
using TicketManager.Extensions.ViewModel;
using TicketManager.Repository;
using TicketManager.ViewModels.Comment;

namespace TicketManager.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _comment;

        public CommentService(ICommentRepository commentRepository)
        {
            _comment = commentRepository;
        }

        public async Task<IEnumerable<CommentGetViewModel>> GetAllAsync(int ticketID)
        {
            var result = await _comment.GetAll(ticketID);
            return result.Select(x => x.ToViewModel());
        }

        public async Task<int> GetLastIDFromTicket(int ticketID)
        {
            var result = await _comment.GetLastCommentIDFromTicket(ticketID);
            //var result = await _comment.GetById(id);
            //return result.ToViewModel();
            return result;
        }

        public async Task<CommentGetViewModel> GetByID(int id)
        {
            var result = await _comment.GetByID(id);

            return result.ToViewModel();
        }

        public async Task<int> CreateAsync(CommentAddEditViewModel ticket)
        {
            return await _comment.Create(ticket.ToModel());
        }

        public async Task<int> RemoveAsync(int id)
        {
            var ticketID = await _comment.GetTicketIDFromComment(id);
            var lastCommentID = await _comment.GetLastCommentIDFromTicket(ticketID);

            if (id.NotEquals(lastCommentID))
            {
                throw new ValidationException("Comment ID is not the last one from the ticket.");
            }

            return await _comment.Delete(id);
        }
    }
}
