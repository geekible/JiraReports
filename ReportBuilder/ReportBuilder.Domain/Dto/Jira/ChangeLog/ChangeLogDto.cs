namespace ReportBuilder.Domain.Dto.Jira.ChangeLog;

public class ChangeLogDto
{
    public int startAt { get; set; }
    public int maxResults { get; set; }
    public int total { get; set; }
    public List<HistoryDto> histories { get; set; }
}