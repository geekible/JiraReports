using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ReportBuilder.Domain.Dto.ReportBuilder
{
    public class ReportDefinitionDtoValidator : AbstractValidator<ReportDefinitionDto>
    {
        public ReportDefinitionDtoValidator()
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
}
