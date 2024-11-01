using ReportBuilder.Domain.Dto.Jira.ChangeLog;

namespace ReportBuilder.Domain.Dto.Jira;

public class IssueDto
{
    public string expand { get; set; }
    public string id { get; set; }
    public string self { get; set; }
    public string key { get; set; }
    public IssueFieldsDto fields { get; set; }
    public ChangeLogDto changelog { get; set; }
}