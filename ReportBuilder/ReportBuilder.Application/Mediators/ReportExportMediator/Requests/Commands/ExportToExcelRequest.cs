using MediatR;
using ReportBuilder.Domain.Dto.Report;

namespace ReportBuilder.Application.Mediators.ReportExportMediator.Requests.Commands;

public class ExportToExcelRequest : IRequest<byte[]>
{
    public List<ReportResultDto> Issues { get; set; }
    public string Filename { get; set; }
}