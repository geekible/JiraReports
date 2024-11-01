namespace ReportBuilder.Domain.Dto.Jira;

public class JiraResponseFieldDto
{
    public string FieldName { get; set; }
    public string Alias { get; set; }
    public string DataType { get; set; }
}

public class JiraResponseFieldList
{
    public JiraResponseFieldList()
    {
        Fields = new List<JiraResponseFieldDto>();
    }

    public List<JiraResponseFieldDto> Fields { get; set; }

    public JiraResponseFieldList BuildFieldList => new JiraResponseFieldList
    {
        Fields =
        [
            new() { FieldName = "key", Alias = "Key", DataType = "string" },
            new() { FieldName = "summary", Alias = "Summary", DataType = "string" },
            new() { FieldName = "issuetype", Alias = "Issue Type", DataType = "object" },
            new() { FieldName = "parent", Alias = "Parent", DataType = "object" },
            new() { FieldName = "status", Alias = "Status", DataType = "object" },
            new() { FieldName = "priority", Alias = "Priority", DataType = "object" },
            new() { FieldName = "duedate", Alias = "Due Date", DataType = "datetime" },
            new() { FieldName = "customfield_10020", Alias = "Sprints", DataType = "list<object>" },
            new() { FieldName = "issuelinks", Alias = "Issue Links", DataType = "list<object>" },
            new() { FieldName = "assignee", Alias = "Assigned To", DataType = "object" },
            new() { FieldName = "changelog", Alias = "History", DataType = "list<object>" },
            new() { FieldName = "components", Alias = "Components", DataType = "list<object>" },
            new() { FieldName = "customfield_10038", Alias = "Story Points", DataType = "number" },
            new() { FieldName = "customfield_10001", Alias = "Team", DataType = "string" }
        ]
    };

}