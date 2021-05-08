using System.Threading.Tasks;
using TicketManager.Repository.Models;

namespace TicketManager.Repository
{
    public interface ICommentRepository
    {
        Task Insert(Comment comment);
    }
}