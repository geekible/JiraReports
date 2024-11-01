namespace ReportBuilder.Domain.Dto.Jql;

public class JqlRequestDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Endpoint { get; set; } = "giacom.atlassian.net/rest/api/3/search";
    public string JqlQuery { get; set; }

    public string Fields { get; set; } =
        "key, duedate, parent, status, priority, issuetype, assignee, summary, customfield_10020, customfield_10038, changelog";

    public bool ExpandChangeLog { get; set; } = true;
    public int StartPage { get; set; } = 0;
    public int PageSize { get; set; } = 500;

}