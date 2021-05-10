using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Repository.Configuration
{
    public static class DependencyManager
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            //services.AddTransient<IUserCompanyRepository, UserCompanyRepository>();
        }
    }
}
