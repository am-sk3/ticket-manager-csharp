using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Repository.Factories;
using TicketManager.Repository.Models;

namespace TicketManager.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly IDatabaseFactory _databaseFactory;

        public TicketRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public async Task GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task GetTicketsByUser(int userID)
        {
            throw new NotImplementedException();
        }

        public async Task GetTicket(int ticketID)
        {
            throw new NotImplementedException();
        }

        public async Task Create(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int ticketID)
        {
            throw new NotImplementedException();
        }

        public async Task MarkClosed(int ticketID)
        {
            throw new NotImplementedException();
        }

    }
}
