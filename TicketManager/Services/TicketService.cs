using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Repository;
using TicketManager.ViewModels.Ticket;

namespace TicketManager.Services
{
    public class TicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<IEnumerable<TicketGetAllViewModel>> GetAllAsync()
        {
            //var result = await _user.GetAll();
            //return result.Select(x => x.ToViewModel());
            throw new NotImplementedException();
        }

        public async Task<TicketGetViewModel> GetByIdAsync(int id)
        {
            //var result = await _user.GetByID(userID);
            //return result.ToViewModel();
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(TicketAddViewModel ticket)
        {
            //var request = user.ToUserModel();

            //return await _user.Create(request);
            throw new NotImplementedException();
        }

        //public async Task<int> EditAsync(UserAddEditViewModel user, int userID)
        //{
        //    var request = user.ToUserModel();
        //    request.ID = userID;

        //    return await _user.Update(request);
        //}

        public async Task<int> RemoveAsync(int id)
        {
            //return await _user.Delete(userID);
            throw new NotImplementedException();
        }

    }
}
