namespace ReportBuilder.Domain.Dto.Jira.ChangeLog;

public class HistoryDto
{
    public string id { get; set; }
    public AuthorDto author { get; set; }
    public DateTime created { get; set; }
    public List<ItemDto> items { get; set; }
}