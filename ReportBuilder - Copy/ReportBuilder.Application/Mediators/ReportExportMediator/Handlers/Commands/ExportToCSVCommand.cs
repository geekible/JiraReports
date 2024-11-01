using AutoMapper;
using MediatR;
using ReportBuilder.Application.Mediators.ReportExportMediator.Requests.Commands;
using ReportBuilder.Domain.Configuration;
using ReportBuilder.Domain.Dto.Export;
using ReportBuilder.Domain.Dto.Report;
using ReportBuilder.Infrastructure.Export.Contracts;

namespace ReportBuilder.Application.Mediators.ReportExportMediator.Handlers.Commands;

public class ExportToCSVCommand : IRequestHandler<ExportToCSVRequest, byte[]>
{
    private readonly IMapper _mapper;
    private readonly IReportResultToCSV _csvWriter;
    
    public ExportToCSVCommand(
        IMapper mapper,
        IReportResultToCSV csvWriter)
    {
        _mapper = mapper;
        _csvWriter = csvWriter;
    }

    public async Task<byte[]> Handle(ExportToCSVRequest request, CancellationToken cancellationToken)
    {
        var issues = request.Issues.Select(issue => _mapper.Map<ReportResultDto, ReportResultExportDto>(issue))
            .ToList();
        var stream = await _csvWriter.ExportToCsv(issues, "issues.csv");
        return stream;
    }
}