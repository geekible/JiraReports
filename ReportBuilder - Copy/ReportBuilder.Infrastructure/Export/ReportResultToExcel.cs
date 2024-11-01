using System.Data;
using ReportBuilder.Domain.Dto.Export;
using ReportBuilder.Infrastructure.Export.Contracts;
using Spire.Xls;

namespace ReportBuilder.Infrastructure.Export;

public class ReportResultToExcel : IReportResultToExcel
{
    private const TableBuiltInStyles tableStyle = TableBuiltInStyles.TableStyleLight9;
    private const string dateFormat = "dd MMM yyyy";

    private DataTable ResultsDataTable()
    {
        var dt = new DataTable();

        dt.Columns.Add("Key");
        dt.Columns.Add("Parent Key");
        dt.Columns.Add("Issue Type");
        dt.Columns.Add("Priority");
        dt.Columns.Add("Status");
        dt.Columns.Add("Summary");
        dt.Columns.Add("Story Points", typeof(decimal));
        dt.Columns.Add("Start Date");
        dt.Columns.Add("Due Date");
        dt.Columns.Add("Est Completion Date");
        dt.Columns.Add("Days Blocked", typeof(int));
        dt.Columns.Add("Percent Complete", typeof(decimal));
        dt.Columns.Add("Assigned To");

        return dt;
    }

    private DataTable AddRowsToDataTable(List<ReportResultExportDto> issues, DataTable dataTable)
    {
        foreach (var issue in issues)
        {
            dataTable.Rows.Add(
                issue.Key,
                issue.ParentKey,
                issue.IssueType,
                issue.Priority,
                issue.Status,
                issue.Summary,
                (int)issue.StoryPoints,
                issue.WorkStartedDate.HasValue ? issue.WorkStartedDate.Value.ToString(dateFormat) : string.Empty,
                issue.DueDate.HasValue ? issue.DueDate.Value.ToString(dateFormat) : string.Empty,
                issue.EstimatedDateCompleted.HasValue ? issue.EstimatedDateCompleted.Value.ToString(dateFormat) : string.Empty,
                issue.DaysInBlocked,
                issue.PercentComplete,
                issue.AssignedTo
            );
        }

        return dataTable;
    }

    private void BuildIssuesWorkSheet(Workbook wb, DataTable dt)
    {
        var ws = wb.Worksheets.Add("Issues");

        ws.ListObjects.Create("Table", ws.Range[1, 1, dt.Rows.Count+1, dt.Columns.Count]);
        ws.ListObjects[0].BuiltInTableStyle = tableStyle;
        ws.InsertDataTable(dt, true, 1, 1, true);
    }

    public async Task<byte[]> ExportToExcel(List<ReportResultExportDto> issues, string filename)
    {
        var dt = ResultsDataTable();
        dt = AddRowsToDataTable(issues, dt);

        var wb = new Workbook();
        wb.Worksheets.Clear();
        BuildIssuesWorkSheet(wb, dt);

        var ms = new MemoryStream();
        wb.SaveToStream(ms, FileFormat.Version2016);

        var content = ms.ToArray();

        return content;
    }
}