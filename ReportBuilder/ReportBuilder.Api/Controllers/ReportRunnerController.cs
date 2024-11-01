using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReportBuilder.Application.Mediators.JqlReportMediator.Requests.Queries;
using ReportBuilder.Application.Mediators.ReportDefinitionMediator.Requests.Queries;
using ReportBuilder.Domain.Dto.Jql;

namespace ReportBuilder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportRunnerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ReportDefinitionController> _logger;

        public ReportRunnerController(IMediator mediator, ILogger<ReportDefinitionController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetReportResults(string username, string password, int reportDefId)
        {
            try
            {
                var reportDefResult = await _mediator.Send(new GetReportDefinitionByIdRequest
                {
                    ReportDefinitionId = reportDefId
                });

                if (!reportDefResult.IsSuccessful) return BadRequest(reportDefResult);

                var reportResults = await _mediator.Send(new GetJqlResponseRequest
                {
                    JqlRequest = new JqlRequestDto
                    {
                        Username = username,
                        Password = password,
                        Endpoint = reportDefResult.Result.Endpoint,
                        JqlQuery = reportDefResult.Result.JqlQuery,
                        Fields = reportDefResult.Result.Fields,
                        ExpandChangeLog = reportDefResult.Result.ExpandChangeLog,
                        StartPage = 0,
                        PageSize = 50,
                    }
                });

                return Ok(reportResults);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{nameof(ReportRunnerController)} error at {nameof(GetReportResults)}");
                return BadRequest("error getting report date");
            }
        }

        [HttpPost("run-jql")]
        public async Task<IActionResult> RunJqlReport([FromBody] JqlRequestDto jqlRequest)
        {
            try
            {
                var results = await _mediator.Send(new GetJqlResponseRequest
                {
                    JqlRequest = jqlRequest
                });

                return Ok(results);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{nameof(ReportRunnerController)} error at {nameof(RunJqlReport)}");
                return BadRequest("error getting report date");
            }
        }
    }
}
