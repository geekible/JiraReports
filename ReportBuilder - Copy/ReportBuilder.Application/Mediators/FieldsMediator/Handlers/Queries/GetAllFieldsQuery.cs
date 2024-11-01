using AutoMapper;
using MediatR;
using ReportBuilder.Application.Mediators.FieldsMediator.Queries.Queries;
using ReportBuilder.Domain.Dto.Field;
using ReportBuilder.Domain.Dto.Responses;
using ReportBuilder.Infrastructure.DataAccess.Repositories.Contracts;

namespace ReportBuilder.Application.Mediators.FieldsMediator.Handlers.Queries;

public class GetAllFieldsQuery : IRequestHandler<GetAllFieldsRequest, QueryResponseListDto<FieldDto>>
{
    private readonly IFieldsRepository _fieldsRepository;
    private readonly IMapper _mapper;

    public GetAllFieldsQuery(IFieldsRepository fieldsRepository, IMapper mapper)
    {
        _fieldsRepository = fieldsRepository;
        _mapper = mapper;
    }

    public async Task<QueryResponseListDto<FieldDto>> Handle(GetAllFieldsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var fields = await _fieldsRepository.GetAll();
            var results = _mapper.Map<List<FieldDto>>(fields);
            return new QueryResponseListDto<FieldDto>
            {
                EntityId = 0,
                IsSuccessful = true,
                Results = results
            };
        }
        catch (Exception e)
        {
            return new QueryResponseListDto<FieldDto>
            {
                EntityId = 0,
                IsSuccessful = false,
                Exception = e
            };
        }
    }
}