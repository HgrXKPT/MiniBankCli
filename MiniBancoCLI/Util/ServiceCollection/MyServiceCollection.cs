using Microsoft.Extensions.DependencyInjection;
using MiniBancoCLI.Core.Interfaces;
using MiniBancoCLI.Core.Repositories;
using MiniBancoCLI.Core.Services;
using MiniBancoCLI.Infrastructure.Repositories;

namespace MiniBancoCLI.Util.ServiceCollection {
    internal static class MyServiceCollection {

        public static IServiceCollection addServices(this IServiceCollection services) {

            //Services
            services.AddScoped<IContaService,ContaService>();



            //Repositories
            services.AddScoped<IContaRepository,ContaRepository>();

            return services;
        }

    }
}
