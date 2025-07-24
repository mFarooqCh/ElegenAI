using System.Text.Json.Serialization;

namespace ElegenAI.API.Captions.Models;

public class GeminiRequest
{
    [JsonPropertyName("contents")] public required List<Content> Contents { get; set; }
    [JsonPropertyName("generationConfig")] public GenerationConfig? GenerationConfig { get; set; }
    [JsonPropertyName("systemInstruction")] public required Content SystemInstructions { get; set; }
}