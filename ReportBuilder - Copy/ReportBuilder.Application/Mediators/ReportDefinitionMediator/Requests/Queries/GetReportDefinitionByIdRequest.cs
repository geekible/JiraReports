using MediatR;
using ReportBuilder.Domain.Dto.ReportBuilder;
using ReportBuilder.Domain.Dto.Responses;

namespace ReportBuilder.Application.Mediators.ReportDefinitionMediator.Requests.Queries;

public class GetReportDefinitionByIdRequest : IRequest<QueryResponseSingleRecordDto<ReportDefinitionDto>>
{
    public int ReportDefinitionId { get; set; }
}