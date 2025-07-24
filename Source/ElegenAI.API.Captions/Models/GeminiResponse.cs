//using System.Text.Json.Serialization;

//namespace ElegenAI.API.Captions.Models;

//public sealed class GeminiResponse
//{
//    [JsonPropertyName("candidates")] public List<Candidate>? Candidates { get; set; }
//    [JsonPropertyName("usageMetadata")] public UsageMetadata? UsageMetadata { get; set; }
//    [JsonPropertyName("promptFeedback")] public PromptFeedback? PromptFeedback { get; set; }
//    [JsonPropertyName("modelVersion")] public string ModelVersion { get; set; } = string.Empty;
//}

//public class PromptFeedback
//{
//}

//public enum BlockReason
//{
//    BLOCK_REASON_UNSPECIFIED,    //Default value. This value is unused.
//    SAFETY,  //Prompt was blocked due to safety reasons. Inspect safetyRatings to understand which safety category blocked it.
//    OTHER,   //Prompt was blocked due to unknown reasons.
//    BLOCKLIST,  //Prompt was blocked due to the terms which are included from the terminology blocklist.
//    PROHIBITED_CONTENT, //Prompt was blocked due to prohibited content.
//    IMAGE_SAFETY,    //Candidates blocked due to unsafe image generation content.
//}