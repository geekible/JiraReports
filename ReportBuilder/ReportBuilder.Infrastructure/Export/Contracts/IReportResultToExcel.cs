using ReportBuilder.Domain.Dto.Export;

namespace ReportBuilder.Infrastructure.Export.Contracts;

public interface IReportResultToExcel
{
    Task<byte[]> ExportToExcel(List<ReportResultExportDto> issues, string filename);
}