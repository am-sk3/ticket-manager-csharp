using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Repository.Factories;

namespace TicketManager.Factories
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private string _connectionString;

        public DatabaseFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("sqlite");
        }

        public IDbConnection GetConnection() => new SqliteConnection(_connectionString);

        public async Task<IDbConnection> GetConnectionAsync() => await Task.FromResult(GetConnection());
    }
}
