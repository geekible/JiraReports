using AutoMapper;
using MediatR;
using ReportBuilder.Application.Mediators.ReportExportMediator.Requests.Commands;
using ReportBuilder.Domain.Dto.Export;
using ReportBuilder.Domain.Dto.Report;
using ReportBuilder.Infrastructure.Export.Contracts;

namespace ReportBuilder.Application.Mediators.ReportExportMediator.Handlers.Commands;

public class ExportToExcelCommand : IRequestHandler<ExportToExcelRequest, byte[]>
{
    private readonly IMapper _mapper;
    private readonly IReportResultToExcel _xlsWriter;

    public ExportToExcelCommand(
        IMapper mapper,
        IReportResultToExcel xlsWriter)
    {
        _mapper = mapper;
        _xlsWriter = xlsWriter;
    }

    public async Task<byte[]> Handle(ExportToExcelRequest request, CancellationToken cancellationToken)
    {
        var issues = request.Issues.Select(issue => _mapper.Map<ReportResultDto, ReportResultExportDto>(issue))
            .ToList();
        var stream = await _xlsWriter.ExportToExcel(issues, "issues.xlsx");
        return stream;
    }
}