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
        Task<Ticket> GetById(int ticketID);
        Task<IEnumerable<Ticket>> GetByCompany(int companyID);
        Task<IEnumerable<Ticket>> GetByUser(int userID);
        Task<int> ChangeStatus(TicketStatus status, int ticketID);
        //Task<int> Update(Ticket ticket);
    }
}