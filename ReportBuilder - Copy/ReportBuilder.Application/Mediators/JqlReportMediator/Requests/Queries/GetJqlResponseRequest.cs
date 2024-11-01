using MediatR;
using ReportBuilder.Domain.Dto.Jql;
using ReportBuilder.Domain.Dto.Report;

namespace ReportBuilder.Application.Mediators.JqlReportMediator.Requests.Queries;

public class GetJqlResponseRequest : IRequest<List<ReportResultDto>>
{
    public JqlRequestDto JqlRequest { get; set; }
}