using Microsoft.Extensions.DependencyInjection;
using ReportBuilder.Infrastructure.DataAccess.Repositories;
using ReportBuilder.Infrastructure.DataAccess.Repositories.Common;
using ReportBuilder.Infrastructure.DataAccess.Repositories.Contracts;

namespace ReportBuilder.Infrastructure.DataAccess;

public static class ServiceCollectionRegistration
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services.AddScoped(typeof(ICommonRepository<>), typeof(CommonRepository<>));

        services.AddScoped<IFieldsRepository, FieldsRepository>();
        services.AddScoped<IReportDefinitionRepository, ReportDefinitionRepository>();

        return services;
    }
}