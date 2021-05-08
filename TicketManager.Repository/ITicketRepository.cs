using System.Threading.Tasks;
using TicketManager.Repository.Models;

namespace TicketManager.Repository
{
    public interface ITicketRepository
    {
        Task Create(Ticket ticket);
        Task Delete(int ticketID);
        Task GetAll();
        Task GetTicket(int ticketID);
        Task GetTicketsByUser(int userID);
        Task MarkClosed(int ticketID);
        Task Update(Ticket ticket);
    }
}