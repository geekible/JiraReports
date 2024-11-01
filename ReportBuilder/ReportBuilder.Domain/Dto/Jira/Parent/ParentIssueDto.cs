namespace ReportBuilder.Domain.Dto.Jira.Parent;

public class ParentIssueDto
{
    public string id { get; set; }
    public string key { get; set; }
    public string self { get; set; }
    public IssueFieldsDto fields { get; set; }
}