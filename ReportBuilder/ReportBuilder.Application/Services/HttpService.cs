using System.Net.Http.Headers;
using System.Text;
using ReportBuilder.Application.Services.Contracts;
using ReportBuilder.Domain.Dto.Jql;

namespace ReportBuilder.Application.Services;

public class HttpService : IHttpService
{
    private string EncodeCredentials(string username, string password)
    {
        var creds = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
        return creds;
    }

    public async Task<string> GetResponse(JqlRequestDto request, int startAt, int pageSize)
    {
        var url =
            $"https://{request.Endpoint}?jql={request.JqlQuery}&fields={request.Fields}&maxResults{pageSize}&startAt={startAt}";

        if (request.ExpandChangeLog)
        {
            url += "&expand=changelog";
        }

        var client = new HttpClient();
        var req = new HttpRequestMessage(HttpMethod.Get, url);

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", EncodeCredentials(request.Username, request.Password));

        var resp = await client.SendAsync(req);
        var jsonString = await resp.Content.ReadAsStringAsync();

        return jsonString;
    }
}