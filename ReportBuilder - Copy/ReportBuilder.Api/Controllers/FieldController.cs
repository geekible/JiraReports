using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReportBuilder.Application.Mediators.FieldsMediator.Queries.Queries;

namespace ReportBuilder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FieldController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<FieldController> _logger;

        public FieldController(IMediator mediator, ILogger<FieldController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("get-all")]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllFields()
        {
            try
            {
                var results = await _mediator.Send(new GetAllFieldsRequest());
                return Ok(results);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{nameof(FieldController)} error at {nameof(GetAllFields)}");
                return BadRequest("error getting fields");
            }
        }
    }
}
