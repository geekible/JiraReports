using MediatR;
using ReportBuilder.Domain.Dto.Field;
using ReportBuilder.Domain.Dto.Responses;

namespace ReportBuilder.Application.Mediators.FieldsMediator.Queries.Queries;

public class GetAllFieldsRequest : IRequest<QueryResponseListDto<FieldDto>>
{
    
}