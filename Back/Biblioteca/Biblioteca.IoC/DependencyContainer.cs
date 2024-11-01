using Biblioteca.Repository.EFCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.IoC;

public static class DependencyContainer
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration, string connectionString)
    {
        services
            .AddEFRepository(configuration, connectionString);

        return services;
    }
}