namespace ReportBuilder.Domain.Dto.ReportBuilder;

public class ReportDefinitionSaveRequestDto
{
    public int Id { get; set; }
    public string ReportName { get; set; }
    public string Endpoint { get; set; }
    public string JqlQuery { get; set; }
    public string Fields { get; set; }
    public bool ExpandChangeLog { get; set; }
}