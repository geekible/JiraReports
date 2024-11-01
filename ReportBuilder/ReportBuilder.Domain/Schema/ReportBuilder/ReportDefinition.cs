using ReportBuilder.Domain.Schema.Common;

namespace ReportBuilder.Domain.Schema.ReportBuilder;

public class ReportDefinition : AuditEntry
{
    public string ReportName { get; set; }
    public string Endpoint { get; set; }
    public string JqlQuery { get; set; }
    public string Fields { get; set; }
    public bool ExpandChangeLog { get; set; } = true;
}