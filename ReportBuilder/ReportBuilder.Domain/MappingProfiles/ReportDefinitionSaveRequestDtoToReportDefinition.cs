using AutoMapper;
using ReportBuilder.Domain.Dto.ReportBuilder;
using ReportBuilder.Domain.Schema.ReportBuilder;

namespace ReportBuilder.Domain.MappingProfiles;

public class ReportDefinitionSaveRequestDtoToReportDefinition : Profile
{
    public ReportDefinitionSaveRequestDtoToReportDefinition()
    {
        CreateMap<ReportDefinitionSaveRequestDto, ReportDefinition>().ReverseMap();
    }
}