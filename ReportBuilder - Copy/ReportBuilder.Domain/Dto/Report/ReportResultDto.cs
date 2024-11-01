namespace ReportBuilder.Domain.Dto.Report;

public class ReportResultDto
{
    public string Key { get; set; }
    public string ParentKey { get; set; }
    public string Summary { get; set; }
    public string Priority { get; set; }
    public string IssueType { get; set; }
    public string Status { get; set; }
    public string StatusCategory { get; set; }
    public decimal StoryPoints { get; set; }
    public int DaysInBlocked { get; set; }
    public DateTime? WorkStartedDate { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? EstimatedDateCompleted { get; set; }
    public decimal PercentComplete { get; set; }
    public List<ReportSprintDto> InSprints { get; set; } = new List<ReportSprintDto>();
    public ReportSprintDto CurrentSprint { get; set; }
    public string AssignedTo { get; set; }
    public List<ReportIssueLinkDto> IssueLinks { get; set; }
}