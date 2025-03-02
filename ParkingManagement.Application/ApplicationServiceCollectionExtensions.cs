using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ParkingManagement.Application.Database;
using ParkingManagement.Application.Repositories;
using ParkingManagement.Application.Services;

namespace ParkingManagement.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IParkingRepository, ParkingRepository>();
        services.AddSingleton<IParkingRepository, ParkingRepository>();
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Singleton);
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services,
        string connectionString)
    {
        services.AddSingleton<IDbConnectionFactory>(_ =>
            new NpgsqlConnectionFactory(connectionString));
        services.AddSingleton<DbInitializer>();
        return services;
    }
}
