using System;
using TicketManager.Repository.Models;

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
    }
}
