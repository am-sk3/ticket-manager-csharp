using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Repository.Models;
using TicketManager.ViewModels.UserCompany;

namespace TicketManager.Extensions.ViewModel
{
    public static class UserCompanyViewModelExtensions
    {
        public static UserCompanyGetViewModel ToViewModel(this UserCompany userCompany)
        {
            return new UserCompanyGetViewModel
            {
                ID = userCompany.ID,
                Name = userCompany.Name
            };
        }

        public static CompanyUserGetViewModel ToViewModel(this CompanyUser userCompany)
        {
            return new CompanyUserGetViewModel
            {
                ID = userCompany.ID,
                Name = userCompany.Name
            };
        }
    }
}
