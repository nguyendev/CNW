using Final.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(
        this IServiceCollection services)
        {
            services.AddSingleton<ITicketService, TicketService>();
            // and a lot more Services
            return services;
        }
    }
}