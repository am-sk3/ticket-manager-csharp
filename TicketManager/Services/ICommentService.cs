using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManager.ViewModels.Comment;

namespace TicketManager.Services
{
    public interface ICommentService
    {
        Task<int> CreateAsync(CommentAddEditViewModel ticket);
        Task<IEnumerable<CommentGetViewModel>> GetAllAsync(int ticketID);
        Task<CommentGetViewModel> GetByID(int id);
        Task<int> GetLastIDFromTicket(int ticketID);
        Task<int> RemoveAsync(int id);
    }
}