using System.Text.Json.Serialization;

namespace ElegenAI.API.Captions.Models;

public class InlineData
{
    [JsonPropertyName("mime_type")]
    public string MimeType { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;
}