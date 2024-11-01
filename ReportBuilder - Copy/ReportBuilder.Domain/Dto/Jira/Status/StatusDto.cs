namespace ReportBuilder.Domain.Dto.Jira.Status;

public class StatusDto
{
    public string self { get; set; }
    public string description { get; set; }
    public string iconUrl { get; set; }
    public string name { get; set; }
    public string id { get; set; }
    public StatusCategoryDto statusCategory { get; set; }
}