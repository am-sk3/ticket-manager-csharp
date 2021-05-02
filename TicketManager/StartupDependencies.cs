using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Factories;
using TicketManager.Repository;

namespace TicketManager
{
    public static class StartupDependencies
    {
        public static void LoadDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseFactory, DatabaseFactory>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserCompanyRepository, UserCompanyRepository>();
        }
    }
}
