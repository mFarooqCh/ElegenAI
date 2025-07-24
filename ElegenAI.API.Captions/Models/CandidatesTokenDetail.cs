using System.Text.Json.Serialization;

namespace ElegenAI.API.Captions.Models;

public class CandidatesTokenDetail
{
    [JsonPropertyName("modality")]
    public string? Modality { get; set; }

    [JsonPropertyName("tokenCount")]
    public int TokenCount { get; set; }
}