using Core.Interfaces.Repositories;
using FluentValidation;
using Infraestructura.Contexts;
using Infraestructura.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mapster;
using MapsterMapper;
using System.Reflection;
using Core.DTOs.Customer;
using Infraestructura.Validation.Customer;
using Core.DTOs.Card;
using Infraestructura.Validation.Card;
using Core.DTOs.Charge;
using Infraestructura.Validation.Charge;
using Core.DTOs.Payment;
using Infraestructura.Validation.Payment;
using Core.Interfaces.Services;
using Infraestructura.Services;

namespace Infraestructura;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddRepositories();
        services.AddServices();
        services.AddDatabase(configuration);
        services.AddValidations();
        services.AddMapping();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<IChargeRepository, ChargeRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<ITransactionsRepository, TransactionRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IEntityRepository, EntityRepository>();
        services.AddScoped<ICustomerEntityProductRepository, CustomerEntityProductRepository>();

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
        services.AddScoped<IValidator<CreateCardDTO>, CreateCardValidation>();
        services.AddScoped<IValidator<CreateChargeDTO>, CreateChargeValidation>();
        services.AddScoped<IValidator<CreatePaymentDTO>, CreatePaymentValidation>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICardServices, CardService>();
        services.AddScoped<ICustomerService, CustomerService>();

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