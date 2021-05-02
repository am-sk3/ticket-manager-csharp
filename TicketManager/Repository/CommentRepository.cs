using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Entities;
using TicketManager.Factories;

namespace TicketManager.Repository
{
    internal class CommentRepository : ICommentRepository
    {
        private readonly IDatabaseFactory _databaseFactory;

        internal CommentRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public async Task Insert(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
