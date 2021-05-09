using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManager.Repository.Models;
using TicketManager.ViewModels.Ticket;

namespace TicketManager.Services
{
    public interface ITicketService
    {
        Task<int> ChangeStatusAsync(TicketStatus status, int ticketID);
        Task<int> CreateAsync(TicketAddViewModel ticket);
        Task<IEnumerable<TicketGetAllViewModel>> GetAllAsync();
        Task<IEnumerable<TicketGetAllViewModel>> GetByCompany(int companyID);
        Task<TicketGetViewModel> GetByIdAsync(int id);
        Task<IEnumerable<TicketGetAllViewModel>> GetByUser(int userID);
        Task<int> RemoveAsync(int id);
    }
}