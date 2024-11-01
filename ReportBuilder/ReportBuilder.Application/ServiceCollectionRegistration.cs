using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ReportBuilder.Application.Services;
using ReportBuilder.Application.Services.Contracts;

namespace ReportBuilder.Application;

public static class ServiceCollectionRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddScoped<IHttpService, HttpService>();

        return services;
    }
}