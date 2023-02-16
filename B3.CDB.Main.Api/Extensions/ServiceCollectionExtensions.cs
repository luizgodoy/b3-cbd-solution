using B3.CDB.Main.Api.Supervisor;
using Microsoft.Extensions.DependencyInjection;

namespace B3.CDB.Main.Api.Extensions
{    
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSupervisor(this IServiceCollection services)
        {
            services.AddScoped<IDomainSupervisor, DomainSupervisor>();
            return services;
        }
    }
}
