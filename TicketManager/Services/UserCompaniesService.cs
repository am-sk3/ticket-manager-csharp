using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Extensions.ViewModel;
using TicketManager.Repository;
using TicketManager.ViewModels.UserCompany;

namespace TicketManager.Services
{
    public class UserCompaniesService : IUserCompaniesService
    {
        private readonly IUserCompanyRepository _userCompanyRepository;
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;

        public UserCompaniesService(IUserCompanyRepository userCompanyRepository, IUserService userService, ICompanyService companyService)
        {
            _userCompanyRepository = userCompanyRepository;
            _userService = userService;
            _companyService = companyService;
        }

        public async Task<int> AddCompanyToUser(int userID, UserCompanyAddViewModel company)
        {
            var result = await ValidateUserAndCompany(userID, company.CompanyID);

            if (result.Equals(0))
                return result;

            return await _userCompanyRepository.AddUserToCompany(userID, company.CompanyID);
        }

        public async Task<int> AddUserToCompany(int companyID, CompanyUserAddViewModel user)
        {
            var result = await ValidateUserAndCompany(user.UserID, companyID);

            if (result.Equals(0))
                return result;

            return await _userCompanyRepository.AddUserToCompany(user.UserID, companyID);
        }

        public async Task<IEnumerable<UserCompanyGetViewModel>> GetAllUsersFromCompany(int company)
        {
            var result = await _userCompanyRepository.GetAllUsersFromCompany(company);
            return result.Select(x => x.ToViewModel());
        }
        public async Task<IEnumerable<CompanyUserGetViewModel>> GetAllCompaniesFromUserID(int userID)
        {
            var result = await _userCompanyRepository.GetAllCompaniesFromUserID(userID);
            return result.Select(x => x.ToViewModel());
        }

        public async Task<int> RemoveUserFromCompany(int userID, int companyID)
        {
            return await _userCompanyRepository.RemoveUserFromCompany(userID, companyID);
        }

        private async Task<int> ValidateUserAndCompany(int userID, int companyID)
        {
            var userInfo = await _userService.GetByIdAsync(userID);
            var companyInfo = await _companyService.GetByIDAsync(companyID);

            if (userInfo is null || companyInfo is null)
                return 0;

            return 1;
        }
    }
}
