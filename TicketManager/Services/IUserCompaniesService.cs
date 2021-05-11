using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManager.ViewModels.UserCompany;

namespace TicketManager.Services
{
    public interface IUserCompaniesService
    {
        Task<int> AddCompanyToUser(int userID, UserCompanyAddViewModel company);
        Task<int> AddUserToCompany(int companyID, CompanyUserAddViewModel user);
        Task<IEnumerable<CompanyUserGetViewModel>> GetAllCompaniesFromUserID(int userID);
        Task<IEnumerable<UserCompanyGetViewModel>> GetAllUsersFromCompany(int company);
        Task<int> RemoveUserFromCompany(int userID, int companyID);
    }
}