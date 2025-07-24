using System.Text.Json.Serialization;

namespace ElegenAI.API.Captions.Models;

public class GenerationConfig
{
    [JsonPropertyName("thinkingConfig")] public ThinkingConfig? ThinkingConfig { get; set; }

    [JsonPropertyName("maxOutputTokens")] public int MaxOutputTokens { get; set; } = 500;

    [JsonPropertyName("temperature")] public float Temperature { get; set; } = 1.0F;
    [JsonPropertyName("topP")] public float TopP { get; set; } = 0.95F; // top_p must be in the range [0.0, 1.0]
    [JsonPropertyName("topK")] public float TopK { get; set; } = 10F;
    /// <summary>
    /// Supported mimetypes:
    /// - text/plain: (default) Text output.
    /// - application/json: JSON response in the candidates.
    ///   The model needs to be prompted to output the appropriate response type,
    ///   otherwise the behavior is undefined.
    /// </summary>
    [JsonPropertyName("responseMimeType")] public string ResponseMimeType { get; set; } = "text/plain"; //"application/json";
    //[JsonPropertyName("responseSchema")] public string ResponseSchema { get; set; } = "application/json"; //"text/plain";
}