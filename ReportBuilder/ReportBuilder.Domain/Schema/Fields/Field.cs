using ReportBuilder.Domain.Schema.Common;

namespace ReportBuilder.Domain.Schema.Fields;

public class Field : AuditEntry
{
    public string FieldAlias { get; set; }
    public string FieldName { get; set; }
    public string DataType { get; set; }
}