using Biblioteca.Interfaces.IRepositories;
using Biblioteca.Repository.EFCore.Contexts;
using Biblioteca.Repository.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Repository.EFCore;

public static class DependencyInjection
{
    public static IServiceCollection AddEFRepository(this IServiceCollection services, IConfiguration configuration, string connectionString)
    {
        services.AddDbContext<BibliotecaDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(connectionString));
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddScoped<ILibroDetalleRepository, LibroDetalleRepository>()
                .AddScoped<IListaNegraRepository, ListaNegraRepository>()
                .AddScoped<IPrestamosRepository, PrestamosRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<BibliotecaDbContext>());

        return services;
    }
}