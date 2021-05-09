using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Repository;
using TicketManager.ViewModels.Ticket;
using TicketManager.Extensions.ViewModel;
using TicketManager.Repository.Models;

namespace TicketManager.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticket;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticket = ticketRepository;
        }

        public async Task<IEnumerable<TicketGetAllViewModel>> GetAllAsync()
        {
            var result = await _ticket.GetAll();
            return result.Select(x => x.ToGetAllViewModel());
        }

        public async Task<TicketGetViewModel> GetByIdAsync(int id)
        {
            var result = await _ticket.GetById(id);
            return result.ToViewModel();
        }

        public async Task<IEnumerable<TicketGetAllViewModel>> GetByCompany(int companyID)
        {
            var result = await _ticket.GetByCompany(companyID);
            return result.Select(x => x.ToGetAllViewModel());
        }

        public async Task<IEnumerable<TicketGetAllViewModel>> GetByUser(int userID)
        {
            var result = await _ticket.GetByUser(userID);
            return result.Select(x => x.ToGetAllViewModel());
        }

        public async Task<int> CreateAsync(TicketAddViewModel ticket)
        {
            var request = ticket.ToTicketModel();

            return await _ticket.Create(request);
        }

        public async Task<int> ChangeStatusAsync(TicketStatus status, int ticketID)
        {
            return await _ticket.ChangeStatus(status, ticketID);
        }

        public async Task<int> RemoveAsync(int id)
        {
            return await _ticket.Delete(id);
        }

    }
}
