using System.Threading.Tasks;
using TicketManager.Models;

namespace TicketManager.Repository
{
    internal interface ICommentRepository
    {
        Task Insert(Comment comment);
    }
}