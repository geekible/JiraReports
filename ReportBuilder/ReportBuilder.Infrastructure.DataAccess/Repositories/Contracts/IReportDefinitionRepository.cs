using ReportBuilder.Domain.Schema.ReportBuilder;
using ReportBuilder.Infrastructure.DataAccess.Repositories.Common;

namespace ReportBuilder.Infrastructure.DataAccess.Repositories.Contracts;

public interface IReportDefinitionRepository : ICommonRepository<ReportDefinition>
{
    
}