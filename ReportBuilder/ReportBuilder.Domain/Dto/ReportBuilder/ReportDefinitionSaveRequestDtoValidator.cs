using FluentValidation;

namespace ReportBuilder.Domain.Dto.ReportBuilder;

public class ReportDefinitionSaveRequestDtoValidator : AbstractValidator<ReportDefinitionSaveRequestDto>
{
    public ReportDefinitionSaveRequestDtoValidator()
    {
        RuleFor(r => r.ReportName)
            .NotNull().WithMessage("Report Name must be supplied")
            .NotEmpty().WithMessage("Report Name must be supplied");

        RuleFor(r => r.Endpoint)
            .NotNull().WithMessage("Endpoint must be supplied")
            .NotEmpty().WithMessage("Endpoint must be supplied");

        RuleFor(r => r.JqlQuery)
            .NotNull().WithMessage("JQL Query must be supplied")
            .NotEmpty().WithMessage("JQL Query must be supplied");
    }
}