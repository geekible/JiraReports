using ReportBuilder.Domain.Schema.Fields;
using ReportBuilder.Infrastructure.DataAccess.Repositories.Common;
using ReportBuilder.Infrastructure.DataAccess.Repositories.Contracts;

namespace ReportBuilder.Infrastructure.DataAccess.Repositories;

public class FieldsRepository : CommonRepository<Field>, IFieldsRepository
{
    private readonly ConfigApplicationDbContext _dbConfig;

    public FieldsRepository(ConfigApplicationDbContext dbContext) : base(dbContext)
    {
        _dbConfig = dbContext;
    }
}