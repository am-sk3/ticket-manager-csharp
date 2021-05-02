using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Factories;
using TicketManager.Models;

namespace TicketManager.Repository
{
    public class CommentRepository
    {
        private readonly IDatabaseFactory _databaseFactory;

        public CommentRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        internal async Task Insert(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
