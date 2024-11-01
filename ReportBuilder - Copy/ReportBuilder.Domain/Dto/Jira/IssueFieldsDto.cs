using Newtonsoft.Json;
using ReportBuilder.Domain.Dto.Jira.Parent;
using ReportBuilder.Domain.Dto.Jira.Status;

namespace ReportBuilder.Domain.Dto.Jira;

public class IssueFieldsDto
{
    public string summary { get; set; }
    public IssueTypeDto issuetype { get; set; }
    public ParentIssueDto parent { get; set; }
    public AssigneeDto assignee { get; set; }
    public PriorityDto priority { get; set; }
    public StatusDto status { get; set; }

    [JsonProperty("customfield_10020")]
    public SprintDto[] sprints { get; set; } = Array.Empty<SprintDto>();

    [JsonProperty("customfield_10038")]
    public float? story_points { get; set; }

    [JsonProperty("customfield_10001")]
    public TeamDto team { get; set; }

    public DateTime? duedate { get; set; }
}