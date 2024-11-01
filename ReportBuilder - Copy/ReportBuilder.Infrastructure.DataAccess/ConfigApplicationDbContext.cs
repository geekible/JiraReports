using Microsoft.EntityFrameworkCore;
using ReportBuilder.Domain.Dto.Jira;
using ReportBuilder.Domain.Schema.Common;
using ReportBuilder.Domain.Schema.Fields;
using ReportBuilder.Domain.Schema.ReportBuilder;

namespace ReportBuilder.Infrastructure.DataAccess;

public class ConfigApplicationDbContext : DbContext
{
    public ConfigApplicationDbContext(DbContextOptions opts):base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Field>()
            .HasData(SeedFieldData());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<AuditEntry>())
        {
            entry.Entity.LastModifiedDate = DateTime.Now;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    private static List<Field> SeedFieldData()
    {
        var fieldsList = new JiraResponseFieldList();
        var fields = new List<Field>();
        var idx = 1;
        foreach (var field in fieldsList.BuildFieldList.Fields)
        {
            fields.Add(new Field
            {
                Id = idx,
                FieldAlias = field.Alias,
                FieldName = field.FieldName,
                DataType = field.DataType,
                CreatedBy = "richard",
                CreatedDate = DateTime.Now,
                LastModifiedBy = "richard",
                LastModifiedDate = DateTime.Now
            });
            idx++;
        }

        return fields;
    }

    public DbSet<ReportDefinition> ReportDefinitions { get; set; }
    public DbSet<Field> Fields { get; set; }
}