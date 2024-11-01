using ReportBuilder.Domain.Dto.Jql;

namespace ReportBuilder.Application.Services.Contracts;

public interface IHttpService
{
    Task<string> GetResponse(JqlRequestDto request, int startAt, int pageSize);
}