using AutoMapper;
using MediatR;
using ReportBuilder.Application.Mediators.ReportDefinitionMediator.Requests.Commands;
using ReportBuilder.Domain.Dto.ReportBuilder;
using ReportBuilder.Domain.Dto.Responses;
using ReportBuilder.Domain.Schema.ReportBuilder;
using ReportBuilder.Infrastructure.DataAccess.Repositories.Contracts;

namespace ReportBuilder.Application.Mediators.ReportDefinitionMediator.Handlers.Commands;

public class SaveReportDefinitionCommand : IRequestHandler<SaveReportDefinitionRequest, CommandResponseDto>
{
    private readonly IReportDefinitionRepository _reportDefRepo;
    private readonly IMapper _mapper;
    private readonly ReportDefinitionSaveRequestDtoValidator _reportDefValidator;

    public SaveReportDefinitionCommand(
        IReportDefinitionRepository reportDefRepo,
        IMapper mapper)
    {
        _reportDefRepo = reportDefRepo;
        _mapper = mapper;
        _reportDefValidator = new ReportDefinitionSaveRequestDtoValidator();
    }

    public async Task<CommandResponseDto> Handle(SaveReportDefinitionRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var validationResult = await _reportDefValidator.ValidateAsync(request.ReportDefinition, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new CommandResponseDto
                {
                    IsSuccessful = false,
                    ValidationErrors = validationResult.Errors.Select(s => s.ErrorMessage).ToList()
                };
            }

            var reportDef = _mapper.Map<ReportDefinition>(request.ReportDefinition);
            // TODO: Get real username 
            reportDef.CreatedBy = "Admin";
            reportDef.LastModifiedBy = "Admin";

            if (reportDef.Id == 0)
            {
                await _reportDefRepo.Add(reportDef);
                request.ReportDefinition.Id = reportDef.Id;
            }
            else
            {
                await _reportDefRepo.Update(reportDef);
            }

            return new CommandResponseDto
            {
                EntityId = request.ReportDefinition.Id,
                IsSuccessful = true
            };
        }
        catch (Exception e)
        {
            return new CommandResponseDto
            {
                IsSuccessful = false,
                Exception = e
            };
        }
        
    }
}