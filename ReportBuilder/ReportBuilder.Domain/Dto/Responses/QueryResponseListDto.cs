namespace ReportBuilder.Domain.Dto.Responses;

public class QueryResponseListDto<T> where T : class 
{
    public int EntityId { get; set; }
    public bool IsSuccessful { get; set; }
    public Exception Exception { get; set; }

    public List<T> Results { get; set; }
}