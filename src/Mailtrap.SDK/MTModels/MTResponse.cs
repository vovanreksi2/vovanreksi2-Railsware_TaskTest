using System.Text.Json.Serialization;

namespace Mailtrap.SDK.MailtrapModels;

internal class MTResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("errors")]
    public IEnumerable<string> Errors { get; set; }

    [JsonPropertyName("message_ids")]
    public IEnumerable<string> MessageIds { get; set; }
}