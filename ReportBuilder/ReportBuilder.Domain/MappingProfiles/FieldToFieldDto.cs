using AutoMapper;
using ReportBuilder.Domain.Dto.Field;
using ReportBuilder.Domain.Schema.Fields;

namespace ReportBuilder.Domain.MappingProfiles;

public class FieldToFieldDto : Profile
{
    public FieldToFieldDto()
    {
        CreateMap<Field, FieldDto>().ReverseMap();
    }
}