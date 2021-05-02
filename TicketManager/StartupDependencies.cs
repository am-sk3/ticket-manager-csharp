using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Factories;

namespace TicketManager
{
    public static class StartupDependencies
    {
        public static void LoadDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseFactory, DatabaseFactory>();
        }
    }
}
