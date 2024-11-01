using AutoMapper;
using ReportBuilder.Domain.Dto.Jira;
using ReportBuilder.Domain.Dto.Report;

namespace ReportBuilder.Domain.MappingProfiles;

public class JiraSprintToReportSprintDto : Profile
{
    public JiraSprintToReportSprintDto()
    {
        CreateMap<SprintDto, ReportSprintDto>()
            .ForMember(dest => dest.SprintName,
                opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.StartDate,
                opt => opt.MapFrom(src => src.startDate))
            .ForMember(dest => dest.EndDate,
                opt => opt.MapFrom(src => src.endDate))
            .ReverseMap();
    }
}