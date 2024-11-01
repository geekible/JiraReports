namespace ReportBuilder.Domain.Dto.Jira;

public class SprintDto
{
    public int id { get; set; }
    public string name { get; set; }
    public string state { get; set; }
    public int boardId { get; set; }
    public string goal { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public DateTime completeDate { get; set; }
}