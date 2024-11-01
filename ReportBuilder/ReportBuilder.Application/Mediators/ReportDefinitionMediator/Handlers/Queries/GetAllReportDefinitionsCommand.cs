using MediatR;
using ReportBuilder.Application.Mediators.ReportDefinitionMediator.Requests.Queries;
using ReportBuilder.Domain.Dto.ReportDefinitions;
using ReportBuilder.Domain.Dto.Responses;
using ReportBuilder.Infrastructure.DataAccess.Repositories.Contracts;

namespace ReportBuilder.Application.Mediators.ReportDefinitionMediator.Handlers.Queries;

public class GetAllReportDefinitionsCommand : IRequestHandler<GetAllReportDefinitionsRequest, QueryResponseListDto<ReportDefinitionsListItemDto>>
{
    private readonly IReportDefinitionRepository _reportDefRepo;

    public GetAllReportDefinitionsCommand(IReportDefinitionRepository reportDefRepo)
    {
        _reportDefRepo = reportDefRepo;
    }

    public async Task<QueryResponseListDto<ReportDefinitionsListItemDto>> Handle(GetAllReportDefinitionsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var reportDefs = await _reportDefRepo.GetAll();
            var results = reportDefs.Select(reportDef => new ReportDefinitionsListItemDto { ReportDefinitionId = reportDef.Id, ReportName = reportDef.ReportName }).ToList();

            return new QueryResponseListDto<ReportDefinitionsListItemDto>
            {
                EntityId = 0,
                IsSuccessful = true,
                Results = results
            };
        }
        catch (Exception e)
        {
            return new QueryResponseListDto<ReportDefinitionsListItemDto>
            {
                EntityId = 0,
                IsSuccessful = false,
                Exception = e
            };
        }
    }
}