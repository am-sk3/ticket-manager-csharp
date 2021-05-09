using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManager.Repository.Models;

namespace TicketManager.Repository
{
    public interface ITicketRepository
    {
        Task<int> Create(Ticket ticket);
        Task<int> Delete(int ticketID);
        Task<IEnumerable<Ticket>> GetAll();
        Task<Ticket> GetTicketById(int ticketID);
        Task<IEnumerable<Ticket>> GetTicketsByCompany(int companyID);
        Task<IEnumerable<Ticket>> GetTicketsByUser(int userID);
        Task<int> ChangeTicketStatus(TicketStatus status, int ticketID);
        //Task<int> Update(Ticket ticket);
    }
}