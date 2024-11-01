namespace ReportBuilder.Domain.Dto.Responses;

public class QueryResponseSingleRecordDto<T> where T : class
{
    public int EntityId { get; set; }
    public bool IsSuccessful { get; set; }
    public Exception Exception { get; set; }

    public T Result { get; set; }
}