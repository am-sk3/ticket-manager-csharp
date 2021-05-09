using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManager.Repository.Models;

namespace TicketManager.Repository
{
    public interface ICommentRepository
    {
        Task<int> Create(Comment comment);
        Task<int> Update(Comment comment);
        Task<int> Delete(int commentID);
        Task<int> GetLastCommentIDFromTicket(int ticketID);
        Task<IEnumerable<Comment>> GetAll(int ticketID);

    }
}