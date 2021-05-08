using System;
using TicketManager.Repository.Models;
using TicketManager.ViewModels.Company;

namespace TicketManager.Extensions.ViewModel
{
    public static class CompanyViewModelExtensions
    {
        public static Company ToCompanyModel(this CompanyAddEditViewModel company)
        {
            return new Company
            {
                ID = company.ID,
                Name = company.Name
            };
        }

        public static CompanyGetViewModel ToGetViewModel(this Company company)
        {
            return new CompanyGetViewModel
            {
                ID = company.ID,
                Name = company.Name
            };
        }

        public static CompanyGetAdminViewModel ToGetAdminViewModel(this Company company)
        {
            return new CompanyGetAdminViewModel
            {
                ID = company.ID,
                Name = company.Name,
                IsDeleted = company.IsDeleted
            };
        }
    }
}
