using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReportBuilder.Application.Mediators.ReportDefinitionMediator.Requests.Commands;
using ReportBuilder.Application.Mediators.ReportDefinitionMediator.Requests.Queries;
using ReportBuilder.Domain.Dto.ReportBuilder;
using ReportBuilder.Domain.Dto.Responses;

namespace ReportBuilder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportDefinitionController : ControllerBase
    {
        private readonly ILogger<ReportDefinitionController> _logger;
        private readonly IMediator _mediator;

        public ReportDefinitionController(
            ILogger<ReportDefinitionController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllReportDefinitions()
        {
            try
            {
                var reportDefs = 
                    await _mediator.Send(new GetAllReportDefinitionsRequest());
                return Ok(reportDefs);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{nameof(ReportDefinitionController)} error at {nameof(GetAllReportDefinitions)}");
                return BadRequest("error getting report definitions");
            }
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetById([FromQuery(Name = "reportDefId")] int reportDefId)
        {
            try
            {
                if (reportDefId == 0)
                {
                    return Ok(new QueryResponseSingleRecordDto<ReportDefinitionDto>());
                }

                var def = await _mediator.Send(new GetReportDefinitionByIdRequest
                {
                    ReportDefinitionId = reportDefId
                });

                return Ok(def);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{nameof(ReportDefinitionController)} error at {nameof(GetById)}");
                return BadRequest("error getting report definition");
            }
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> SaveReportDefinition(ReportDefinitionSaveRequestDto reportDefinition)
        {
            try
            {
                var result = await _mediator.Send(new SaveReportDefinitionRequest
                {
                    ReportDefinition = reportDefinition
                });

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{nameof(ReportDefinitionController)} error at {nameof(SaveReportDefinition)}");
                return BadRequest("error getting report definition");
            }
        }
    }
}
