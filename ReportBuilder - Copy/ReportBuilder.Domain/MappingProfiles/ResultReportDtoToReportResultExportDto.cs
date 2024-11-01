using AutoMapper;
using ReportBuilder.Domain.Dto.Export;
using ReportBuilder.Domain.Dto.Report;

namespace ReportBuilder.Domain.MappingProfiles;

public class ResultReportDtoToReportResultExportDto : Profile
{
    public ResultReportDtoToReportResultExportDto()
    {
        CreateMap<ReportResultDto, ReportResultExportDto>()
            .ForMember(dest => dest.SprintName,
                opt => opt.MapFrom(src => src.CurrentSprint.SprintName))
            .ReverseMap();
    }
}