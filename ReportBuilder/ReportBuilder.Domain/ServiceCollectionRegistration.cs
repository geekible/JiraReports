using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ReportBuilder.Domain;

public static class ServiceCollectionRegistration
{
    public static IServiceCollection AddDto(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}