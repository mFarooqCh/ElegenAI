using System.Text.Json.Serialization;

namespace ElegenAI.API.Captions.Models;

public class Part
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("inline_data")]
    public InlineData? InlineData { get; set; }
}