using System.Text.Json.Serialization;

namespace ElegenAI.API.Captions.Models;

public sealed class GenerateContentResponse
{
    [JsonPropertyName("candidates")]
    public List<Candidate>? Candidates { get; set; }

    [JsonPropertyName("usageMetadata")]
    public UsageMetadata? UsageMetadata { get; set; }

    [JsonPropertyName("promptFeedback")]
    public PromptFeedback? PromptFeedback { get; set; }

    [JsonPropertyName("modelVersion")]
    public string ModelVersion { get; set; } = string.Empty;
}

public sealed class Candidate
{
    [JsonPropertyName("content")]
    public Content Content { get; set; } = new Content();

    [JsonPropertyName("metadata")]
    public CandidateMetadata? Metadata { get; set; }
}

public sealed class Content
{
    [JsonPropertyName("parts")] public List<ContentPart> Parts { get; set; } = [];
    [JsonPropertyName("role")] public string Role { get; set; } = string.Empty;
}

public sealed class ContentPart
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("fileData")]
    public FileData? FileData { get; set; }
}

public sealed class FileData
{
    [JsonPropertyName("fileUri")]
    public string FileUri { get; set; } = string.Empty;

    [JsonPropertyName("mimeType")]
    public string MimeType { get; set; } = string.Empty;
}

public sealed class CandidateMetadata
{
    [JsonPropertyName("safetyRating")]
    public SafetyRating? SafetyRating { get; set; }

    [JsonPropertyName("toolExecutionMetadata")]
    public List<ToolExecutionMetadata>? ToolExecutionMetadata { get; set; }
}

public sealed class SafetyRating
{
    [JsonPropertyName("category")]
    public SafetyCategory Category { get; set; }

    [JsonPropertyName("severity")]
    public SafetySeverity Severity { get; set; }

    [JsonPropertyName("probability")]
    public double Probability { get; set; }
}

public enum SafetyCategory
{
    [JsonPropertyName("HARM_CATEGORY_UNSPECIFIED")]
    Unspecified = 0,

    [JsonPropertyName("HARM_CATEGORY_HATE_SPEECH")]
    HateSpeech = 1,

    [JsonPropertyName("HARM_CATEGORY_SEXUALLY_EXPLICIT")]
    SexuallyExplicit = 2,

    [JsonPropertyName("HARM_CATEGORY_DANGEROUS_CONTENT")]
    DangerousContent = 3,

    [JsonPropertyName("HARM_CATEGORY_HARASSMENT")]
    Harassment = 4,

    [JsonPropertyName("HARM_CATEGORY_CIVIC_INTEGRITY")]
    CivicIntegrity = 5
}

public enum SafetySeverity
{
    [JsonPropertyName("SEVERITY_UNSPECIFIED")]
    Unspecified = 0,

    [JsonPropertyName("SEVERITY_LOW")]
    Low = 1,

    [JsonPropertyName("SEVERITY_MEDIUM")]
    Medium = 2,

    [JsonPropertyName("SEVERITY_HIGH")]
    High = 3
}

public sealed class ToolExecutionMetadata
{
    [JsonPropertyName("toolId")]
    public string ToolId { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public ToolExecutionStatus Status { get; set; }

    [JsonPropertyName("output")]
    public string? Output { get; set; }
}

public enum ToolExecutionStatus
{
    [JsonPropertyName("TOOL_STATUS_UNSPECIFIED")]
    Unspecified = 0,

    [JsonPropertyName("TOOL_STATUS_SUCCESS")]
    Success = 1,

    [JsonPropertyName("TOOL_STATUS_FAILURE")]
    Failure = 2
}

public sealed class UsageMetadata
{
    [JsonPropertyName("candidatesTokenCount")]
    public long CandidatesTokenCount { get; set; }

    [JsonPropertyName("promptTokenCount")]
    public long PromptTokenCount { get; set; }

    [JsonPropertyName("totalTokens")]
    public long TotalTokens { get; set; }
}

public sealed class PromptFeedback
{
    [JsonPropertyName("rating")]
    public FeedbackRating Rating { get; set; }

    [JsonPropertyName("annotations")]
    public List<FeedbackAnnotation>? Annotations { get; set; }
}

public enum FeedbackRating
{
    [JsonPropertyName("RATING_UNSPECIFIED")]
    Unspecified = 0,

    [JsonPropertyName("RATING_POSITIVE")]
    Positive = 1,

    [JsonPropertyName("RATING_NEGATIVE")]
    Negative = 2
}

public sealed class FeedbackAnnotation
{
    [JsonPropertyName("span")]
    public TextSpan Span { get; set; } = new TextSpan();

    [JsonPropertyName("category")]
    public AnnotationCategory Category { get; set; }
}

public sealed class TextSpan
{
    [JsonPropertyName("start")]
    public int Start { get; set; }

    [JsonPropertyName("end")]
    public int End { get; set; }
}

public enum AnnotationCategory
{
    [JsonPropertyName("ANNOTATION_CATEGORY_UNSPECIFIED")]
    Unspecified = 0,

    [JsonPropertyName("ANNOTATION_CATEGORY_TOO_LONG")]
    TooLong = 1,

    [JsonPropertyName("ANNOTATION_CATEGORY_INCORRECT")]
    Incorrect = 2,

    [JsonPropertyName("ANNOTATION_CATEGORY_OFF_TOPIC")]
    OffTopic = 3
}
