using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using ReportBuilder.Application.Extensions;
using ReportBuilder.Application.Mediators.JqlReportMediator.Requests.Queries;
using ReportBuilder.Application.Services.Contracts;
using ReportBuilder.Domain.Dto.Jira;
using ReportBuilder.Domain.Dto.Report;

namespace ReportBuilder.Application.Mediators.JqlReportMediator.Handlers.Queries;

public class GetJqlResponseQuery : IRequestHandler<GetJqlResponseRequest, List<ReportResultDto>>
{
    private readonly IHttpService _httpService;
    private readonly IMapper _mapper;

    public GetJqlResponseQuery(
        IMapper mapper,
        IHttpService httpService)
    {
        _mapper = mapper;
        _httpService = httpService;
    }

    public async Task<List<ReportResultDto>> Handle(GetJqlResponseRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var results = new List<ReportResultDto>();
            var moreResults = true;

            do
            {
                var resultSet = await GetIssues(request);
                results.AddRange(resultSet);
                if (resultSet.Count < request.JqlRequest.PageSize) moreResults = false;

                request.JqlRequest.StartPage += request.JqlRequest.PageSize;

            } while (moreResults);
            
            return results;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    private async Task<List<ReportResultDto>> GetIssues(GetJqlResponseRequest request)
    {
        var reportIssues = new List<ReportResultDto>();

        var jsonResults = await _httpService.GetResponse(request.JqlRequest, request.JqlRequest.StartPage, request.JqlRequest.PageSize);
        var results = JsonConvert.DeserializeObject<JiraIssueSearchResponseDto>(jsonResults);

        if (results.issues == null) return reportIssues;

        foreach (var issue in results.issues)
        {
            var reportDto = _mapper.Map<IssueDto, ReportResultDto>(issue);
            _ = issue.ToReportResultDto(reportDto);
            reportDto.CurrentSprint = _mapper.Map<SprintDto, ReportSprintDto>(issue.GetCurrentSprint());
            reportDto.EstimatedDateCompleted = issue.CalculateEstimatedCompletionDate();

            if (issue.fields.sprints != null)
            {
                foreach (var sprint in issue.fields.sprints)
                {
                    reportDto.InSprints.Add(_mapper.Map<SprintDto, ReportSprintDto>(sprint));
                }
            }

            reportIssues.Add(reportDto);
        }

        return reportIssues;
    }
}