namespace ReportBuilder.Domain.Dto.Jira;

public class TeamDto
{
    public string id { get; set; }
    public string name { get; set; }
    public string avatarUrl { get; set; }
    public bool isVisible { get; set; }
    public string Title { get; set; }
    public bool isShared { get; set; }
}