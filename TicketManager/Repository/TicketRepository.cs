using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Factories;
using TicketManager.Models;

namespace TicketManager.Repository
{
    public class TicketRepository
    {
        private readonly IDatabaseFactory _databaseFactory;

        public TicketRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        internal async Task GetAll()
        {
            throw new NotImplementedException();
        }

        internal async Task GetTicketsByUser(int userID)
        {
            throw new NotImplementedException();
        }

        internal async Task GetTicket(int ticketID)
        {
            throw new NotImplementedException();
        }

        internal async Task Create(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        internal async Task Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        internal async Task Delete(int ticketID)
        {
            throw new NotImplementedException();
        }

        internal async Task MarkClosed(int ticketID)
        {
            throw new NotImplementedException();
        }

    }
}
