using System.Threading.Tasks;
using TicketManager.Entities;

namespace TicketManager.Repository
{
    internal interface ICommentRepository
    {
        Task Insert(Comment comment);
    }
}