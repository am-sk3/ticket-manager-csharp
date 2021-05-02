using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Entities;
using TicketManager.Repository;

namespace TicketManager.Services
{
    internal class UserService
    {
        private readonly IUserRepository _user;

        internal UserService(IUserRepository user)
        {
            _user = user;
        }

        public async Task GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task GetUserByID(int userID)
        {
            throw new NotImplementedException();
        }

        public async Task Create(User user)
        {
            throw new NotImplementedException();
        }

        public async Task Edit(User user)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int userID)
        {
            throw new NotImplementedException();
        }

        public async Task ChangePassword(string password, int userID)
        {
            throw new NotImplementedException();
        }


    }
}
