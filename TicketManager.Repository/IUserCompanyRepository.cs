using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManager.Repository.Models;

namespace TicketManager.Repository
{
    public interface IUserCompanyRepository
    {
        Task<int> AddUserToCompany(int userID, int companyID);
        Task<IEnumerable<UserCompany>> GetAllUsersFromCompany(int company);
        Task<IEnumerable<CompanyUser>> GetAllCompaniesFromUserID(int userID);
        Task<int> RemoveUserFromCompany(int userID, int companyID);
    }
}