using MediatR;
using ReportBuilder.Domain.Dto.ReportDefinitions;
using ReportBuilder.Domain.Dto.Responses;

namespace ReportBuilder.Application.Mediators.ReportDefinitionMediator.Requests.Queries;

public class GetAllReportDefinitionsRequest : IRequest<QueryResponseListDto<ReportDefinitionsListItemDto>>
{
    
}