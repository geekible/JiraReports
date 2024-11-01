using AutoMapper;
using MediatR;
using ReportBuilder.Application.Mediators.ReportDefinitionMediator.Requests.Queries;
using ReportBuilder.Domain.Dto.ReportBuilder;
using ReportBuilder.Domain.Dto.Responses;
using ReportBuilder.Infrastructure.DataAccess.Repositories.Contracts;

namespace ReportBuilder.Application.Mediators.ReportDefinitionMediator.Handlers.Queries;

public class GetReportDefinitionByIdCommand : IRequestHandler<GetReportDefinitionByIdRequest, QueryResponseSingleRecordDto<ReportDefinitionDto>>
{
    private readonly IReportDefinitionRepository _reportDefRepo;
    private readonly IMapper _mapper;

    public GetReportDefinitionByIdCommand(
        IReportDefinitionRepository reportDefRepo,
        IMapper mapper)
    {
        _reportDefRepo = reportDefRepo;
        _mapper = mapper;
    }

    public async Task<QueryResponseSingleRecordDto<ReportDefinitionDto>> Handle(GetReportDefinitionByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var reportDef = await _reportDefRepo.Get(request.ReportDefinitionId);
            if (reportDef == null)
            {
                return new QueryResponseSingleRecordDto<ReportDefinitionDto>
                {
                    IsSuccessful = true,
                    Result = new ReportDefinitionDto()
                };
            }

            var dto = _mapper.Map<ReportDefinitionDto>(reportDef);
            return new QueryResponseSingleRecordDto<ReportDefinitionDto>
            {
                EntityId = dto.Id,
                IsSuccessful = true,
                Result = dto
            };
        }
        catch (Exception e)
        {
            return new QueryResponseSingleRecordDto<ReportDefinitionDto>
            {
                EntityId = 0,
                IsSuccessful = false,
                Exception = e
            };
        }
    }
}