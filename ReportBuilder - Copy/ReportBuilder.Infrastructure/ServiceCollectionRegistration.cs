using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReportBuilder.Domain.Configuration;
using ReportBuilder.Infrastructure.Export;
using ReportBuilder.Infrastructure.Export.Contracts;

namespace ReportBuilder.Infrastructure;

public static class ServiceCollectionRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, InfrastructureConfigDto config)
    {
        services.AddSingleton(config);

        services.AddScoped<IReportResultToCSV, ReportResultToCSV>();
        services.AddScoped<IReportResultToExcel, ReportResultToExcel>();

        return services;
    }
}