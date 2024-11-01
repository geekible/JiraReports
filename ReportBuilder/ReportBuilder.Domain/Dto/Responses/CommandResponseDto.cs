namespace ReportBuilder.Domain.Dto.Responses;

public class CommandResponseDto
{
    public int EntityId { get; set; }
    public bool IsSuccessful { get; set; }
    public List<string> ValidationErrors { get; set; }
    public Exception Exception { get; set; }
}