using IAgent.Infra;
using IAgent.Infra.Repositories;
using IAgent.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IAgent.Domain.Interfaces.Repository;
using IAgent.Domain.Interfaces.Services;

namespace IAgent.Infra.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIAgentInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(_ => new MongoContext(
                configuration.GetConnectionString("MongoDb"),
                configuration["MongoDb:DatabaseName"]));

            services.AddScoped<IAgentRepository, AgentRepository>();

            return services;
        }
    }
}
