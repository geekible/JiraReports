using ReportBuilder.Domain.Dto.Export;

namespace ReportBuilder.Infrastructure.Export.Contracts;

public interface IReportResultToCSV
{
    Task<byte[]> ExportToCsv(List<ReportResultExportDto> issues, string filename);
}