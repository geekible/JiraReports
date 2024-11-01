using System.Globalization;
using System.Text;
using CsvHelper;
using ReportBuilder.Domain.Configuration;
using ReportBuilder.Domain.Dto.Export;
using ReportBuilder.Infrastructure.Export.Contracts;

namespace ReportBuilder.Infrastructure.Export;

public class ReportResultToCSV : IReportResultToCSV
{
    private readonly InfrastructureConfigDto _config;

    public ReportResultToCSV(
        InfrastructureConfigDto config)
    {
        _config = config;
    }

    public async Task<byte[]> ExportToCsv(List<ReportResultExportDto> issues, string filename)
    {
        var saveFileName = Path.Combine(_config.ExportFolderPath, filename);

        await using var ms = new MemoryStream();
        await using var sw = new StreamWriter(ms, Encoding.UTF8);
        await using var csv = new CsvWriter(sw, CultureInfo.InvariantCulture);
        await csv.WriteRecordsAsync(issues);
        await sw.FlushAsync();

        var content = ms.ToArray();

        return content;
    }
}