using ReportBuilder.Domain.Dto.Jira;
using ReportBuilder.Domain.Dto.Report;

namespace ReportBuilder.Application.Extensions;

public static class SprintExtensions
{
    public static SprintDto GetCurrentSprint(this IssueDto issue)
    {
        try
        {
            var sprint = issue.fields.sprints.Where(x => x.state is "active" or "future")
                .MinBy(o => o.startDate);

            if (sprint == null)
            {
                return new SprintDto
                {
                    name = "Not In Sprint",
                    startDate = new DateTime(DateTime.Now.AddYears(1).Year, 12, 31),
                    endDate = new DateTime(DateTime.Now.AddYears(1).Year, 12, 31)
                };
            }

            return sprint;
        }
        catch (Exception e)
        {
            return new SprintDto
            {
                name = "Not In Sprint",
                startDate = new DateTime(DateTime.Now.AddYears(1).Year, 12, 31),
                endDate = new DateTime(DateTime.Now.AddYears(1).Year, 12, 31)
            };
        }
        
    }
}