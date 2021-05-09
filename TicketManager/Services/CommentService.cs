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
    public class CommentService
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
            //var result = await _comment.GetById(id);
            //return result.ToViewModel();
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CommentGetViewModel>> GetByCompany(int companyID)
        {
            //var result = await _ticket.GetByCompany(companyID);
            //return result.Select(x => x.ToGetAllViewModel());
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CommentGetViewModel>> GetByUser(int userID)
        {
            //var result = await _ticket.GetByUser(userID);
            //return result.Select(x => x.ToGetAllViewModel());
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(CommentAddEditViewModel ticket)
        {
            //var request = ticket.ToTicketModel();

            //return await _ticket.Create(request);
            throw new NotImplementedException();
        }

        public async Task<int> RemoveAsync(int id)
        {
            var ticketID = await _comment.GetLastCommentIDFromTicket(id);
            var lastCommentID = await _comment.GetLastCommentIDFromTicket(ticketID);

            if (id.NotEquals(lastCommentID))
            {
                throw new ValidationException("Comment ID is not the last one from the ticket.");
            }

            return await _comment.Delete(id);
        }
    }
}
