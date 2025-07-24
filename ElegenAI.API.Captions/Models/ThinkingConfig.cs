using System.Text.Json.Serialization;

namespace ElegenAI.API.Captions.Models;

public class ThinkingConfig
{
    [JsonPropertyName("thinkingBudget")] public int ThinkingBudget { get; set; } = 0; //it depends upon the model
    //2.5 Flash = 0 to 24576
    //2.5 Flash-lite = 512 to 24576
    //Thinking off = "thinkingBudget": 0
    //Turn on dynamic thinking = "thinkingBudget": -1
    [JsonPropertyName("includeThoughts")] public bool IncludeThoughts { get; set; } = false; //it depends upon the model
}