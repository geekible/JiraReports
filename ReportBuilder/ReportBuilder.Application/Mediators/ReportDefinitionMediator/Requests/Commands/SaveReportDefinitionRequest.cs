using MediatR;
using ReportBuilder.Domain.Dto.ReportBuilder;
using ReportBuilder.Domain.Dto.Responses;

namespace ReportBuilder.Application.Mediators.ReportDefinitionMediator.Requests.Commands;

public class SaveReportDefinitionRequest : IRequest<CommandResponseDto>
{
    public ReportDefinitionSaveRequestDto ReportDefinition { get; set; }
}