namespace ReportBuilder.Domain.Dto.Jira.Status;

public class StatusCategoryDto
{
    public string self { get; set; }
    public int id { get; set; }
    public string key { get; set; }
    public string colorName { get; set; }
    public string name { get; set; }
}