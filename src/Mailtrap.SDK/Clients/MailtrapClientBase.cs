using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mailtrap.SDK.Clients;

public abstract class MailtrapClientBase
{
    protected HttpRequestMessage GetDefaultMailtrapMessage(HttpMethod method, string route, string content) =>
        new HttpRequestMessage
        {
            Method = method,
            RequestUri = new Uri(route, UriKind.Relative),
            Headers = { { "Accept", "application/json" } },
            Content = new StringContent(content)
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            }
        };

    protected string SerializeMessageContent<T>(T request) =>
        JsonSerializer.Serialize(request,
            new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
}