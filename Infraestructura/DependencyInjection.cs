using Core.DTOs;
using Core.Interfaces.Repositories;
using Infraestructura.Validation;
using FluentValidation;
using Infraestructura.Contexts;
using Infraestructura.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mapster;
using MapsterMapper;
using System.Reflection;

namespace Infraestructura;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddRepositories();
        services.AddDatabase(configuration);
        services.AddValidations();
        services.AddMapping();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection service, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Bootcamp");

        service.AddDbContext<AplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return service;
    }

    public static IServiceCollection AddValidations(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateCustomerDTO>, CreateValidation>();
        services.AddScoped<IValidator<UpdateCustomerDTO>, UpdateValidation>();

        return services;
    }

    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}