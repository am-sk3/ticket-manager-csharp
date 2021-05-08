using System.Data;
using System.Threading.Tasks;

namespace TicketManager.Repository.Factories
{
    public interface IDatabaseFactory
    {
        IDbConnection GetConnection();
        Task<IDbConnection> GetConnectionAsync();
    }
}