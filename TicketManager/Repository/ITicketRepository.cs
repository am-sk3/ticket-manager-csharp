using System.Threading.Tasks;
using TicketManager.Models;

namespace TicketManager.Repository
{
    internal interface ITicketRepository
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