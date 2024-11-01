using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportBuilder.Domain.Dto.Jira
{
    public class JiraIssueSearchResponseDto
    {
        public string expand { get; set; }
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public IssueDto[] issues { get; set; }
    }
}
