using AutoMapper;
using ReportBuilder.Domain.Dto.ReportBuilder;
using ReportBuilder.Domain.Schema.ReportBuilder;

namespace ReportBuilder.Domain.MappingProfiles;

public class ReportDefinitionToReportDefinitionDto : Profile
{
    public ReportDefinitionToReportDefinitionDto()
    {
        CreateMap<ReportDefinition, ReportDefinitionDto>().ReverseMap();
    }
}