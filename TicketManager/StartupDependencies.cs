using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Factories;
using TicketManager.Repository;
using TicketManager.Services;

namespace TicketManager
{
    public static class StartupDependencies
    {
        public static void LoadDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseFactory, DatabaseFactory>();
            //services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            //services.AddTransient<ITicketRepository, TicketRepository>();
            //services.AddTransient<IUserRepository, UserRepository>();
            //services.AddTransient<IUserCompanyRepository, UserCompanyRepository>();

            services.AddTransient<ICompanyService, CompanyService>();
        }
    }
}
