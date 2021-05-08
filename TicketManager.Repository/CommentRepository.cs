using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Repository.Factories;
using TicketManager.Repository.Models;

namespace TicketManager.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IDatabaseFactory _databaseFactory;

        public CommentRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public async Task Insert(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
