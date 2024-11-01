using ReportBuilder.Domain.Schema.ReportBuilder;
using ReportBuilder.Infrastructure.DataAccess.Repositories.Common;
using ReportBuilder.Infrastructure.DataAccess.Repositories.Contracts;

namespace ReportBuilder.Infrastructure.DataAccess.Repositories;

public class ReportDefinitionRepository : CommonRepository<ReportDefinition>, IReportDefinitionRepository
{
    private readonly ConfigApplicationDbContext _dbConfig;

    public ReportDefinitionRepository(ConfigApplicationDbContext dbContext) : base(dbContext)
    {
        _dbConfig = dbContext;
    }
}