using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Factories;
using TicketManager.Repository.Configuration;
using TicketManager.Repository.Factories;
using TicketManager.Services;

namespace TicketManager
{
    public static class StartupDependencies
    {
        public static void LoadDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseFactory, DatabaseFactory>();

            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<ICommentService, CommentService>();

            services.InitializeRepositories(); //initialize repositories from class
        }
    }
}
