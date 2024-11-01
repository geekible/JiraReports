using ReportBuilder.Domain.Dto.Jira;
using ReportBuilder.Domain.Dto.Report;

namespace ReportBuilder.Application.Extensions;

public static class IssueExtensions
{
    public static ReportResultDto ToReportResultDto(this IssueDto issue, ReportResultDto result)
    {
        result.DaysInBlocked = issue.GetTotalDaysBlocked();
        result.WorkStartedDate = issue.GetWorkStartedDate();
        result.EstimatedDateCompleted = issue.CalculateEstimatedCompletionDate();
        
        return result;
    }

    public static int GetTotalDaysBlocked(this IssueDto issue)
    {
        var daysBlocked = 0;

        if (issue.changelog == null) return 0;

        if (issue.changelog.histories.Count == 0)
        {
            return daysBlocked;
        }

        var history = issue.changelog.histories.OrderBy(o => o.created);
        var isBlocked = false;

        foreach (var hist in history)
        {
            foreach (var histItem in hist.items)
            {
                if (histItem.field.ToLower() == "status" && histItem.toString.ToLower() == "blocked") isBlocked = true;
                if (histItem.field.ToLower() == "status" && histItem.fromString.ToLower() == "blocked") isBlocked = false;
                if (isBlocked)
                {
                    if (hist.created.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
                    { }
                    else
                    {
                        daysBlocked++;
                    }
                }
            }
        }

        return daysBlocked;
    }

    public static DateTime GetWorkStartedDate(this IssueDto issue)
    {
        var startDate = new DateTime();

        if (issue.changelog == null) return startDate;

        if (issue.changelog.histories.Count == 0)
        {
            return startDate;
        }

        var history = issue.changelog.histories.OrderBy(o => o.created);
        foreach (var hist in history)
        {
            foreach (var histItem in hist.items)
            {
                if (histItem.field.ToLower() == "status" && 
                    (histItem.toString.ToLower() == "in development" || histItem.toString.ToLower() == "in progress"))
                {
                    return hist.created;
                }
            }
        }

        return startDate;
    }

    public static DateTime CalculateEstimatedCompletionDate(this IssueDto issue)
    {
        if (issue.changelog == null) return issue.GetActualDateCompleted();

        if (issue.changelog.histories.Count == 0 || issue.fields.status.statusCategory.name.ToLower() == "done")
        {
            return issue.GetActualDateCompleted();
        } 
        if (issue.fields.status.statusCategory.name.ToLower() == "to do")
        {
            var currentSprint = issue.GetCurrentSprint();
            return currentSprint.endDate;
        }

        var daysToComplete = 0;
        if (issue.fields.story_points.HasValue)
        {
            daysToComplete = issue.fields.story_points!.Value.ToDays();
        }
        var daysToAdd = 0;
        var workStartDate = issue.GetWorkStartedDate();
        var workCompletedDate = workStartDate;

        while (daysToComplete > 0)
        {
            workCompletedDate = workCompletedDate.AddDays(daysToAdd);
            if (workCompletedDate.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            { }
            else
            {
                daysToComplete--;
            }

            daysToAdd++;
        }

        return workCompletedDate;
    }

    public static DateTime GetActualDateCompleted(this IssueDto issue)
    {
        if (issue.changelog == null) return new DateTime();

        if (issue.changelog.histories.Count == 0)
        {
            var sprint = issue.fields.sprints.MaxBy(m => m.endDate);

            return sprint.endDate;
        }

        var history = issue.changelog.histories.OrderByDescending(o => o.created);
        foreach (var hist in history)
        {
            foreach (var histItem in hist.items)
            {
                if (histItem.field.ToLower() == "status" && (histItem.toString.ToLower() == "Done" ||
                                                             histItem.toString.ToLower() == "Closed"))
                {
                    return hist.created;
                }
            }
        }

        return new DateTime();
    }
}