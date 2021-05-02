using System.Threading.Tasks;

namespace TicketManager.Repository
{
    internal interface IUserCompanyRepository
    {
        Task<int> AddUserToCompany(int userID, int companyID);
        Task<int> GetAllUsersFromCompany(int company);
        Task GetByUserID(int userID);
        Task GetUserByEmail(string userEmail);
        Task<int> RemoveUserFromCompany(int userID, int companyID);
    }
}