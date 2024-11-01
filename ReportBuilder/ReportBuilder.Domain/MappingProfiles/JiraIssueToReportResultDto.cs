using AutoMapper;
using ReportBuilder.Domain.Dto.Jira;
using ReportBuilder.Domain.Dto.Report;

namespace ReportBuilder.Domain.MappingProfiles;

public class JiraIssueToReportResultDto : Profile
{
    public JiraIssueToReportResultDto()
    {
        CreateMap<IssueDto, ReportResultDto>()
            .ForMember(
                dest => dest.Key,
                opt => opt.MapFrom(src => src.key))
            .ForMember(dest => dest.ParentKey,
                opt => opt.MapFrom(src => src.fields.parent.key))
            .ForMember(dest => dest.Summary,
                opt => opt.MapFrom(src => src.fields.summary))
            .ForMember(dest => dest.Priority,
                opt => opt.MapFrom(src => src.fields.priority.name))
            .ForMember(dest => dest.IssueType,
                opt => opt.MapFrom(src => src.fields.issuetype.name))
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => src.fields.status.name))
            .ForMember(dest => dest.StatusCategory,
                opt => opt.MapFrom(src => src.fields.status.statusCategory.name))
            .ForMember(dest => dest.StoryPoints,
                opt => opt.MapFrom(src => src.fields.story_points))
            .ForMember(dest => dest.AssignedTo,
                opt => opt.MapFrom(src => src.fields.assignee.displayName))
            .ForMember(dest => dest.DueDate,
                opt => opt.MapFrom(src => src.fields.duedate))
            .ReverseMap();
    }
}