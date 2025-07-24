namespace ElegenAI.API.Captions.Common;

public static class AppEnvironment
{
    public static GoogleAIAPISettings GoogleAiApiSettings { get; set; } = new GoogleAIAPISettings
    {
        ApiKey = "AIzaSyBrcHy2IlaJvBRzzN30YWaefg_7-ZCJNKI",
        Endpoint = string.Empty,
        Model = "gemini-2.5-flash",
        TextModelEndpoint = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent",
        VisionModelEndpoint = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent"
    };
}

public sealed class GoogleAIAPISettings
{
    public required string ApiKey { get; set; }
    public required string Endpoint { get; set; }
    public required string Model { get; set; }
    public string TextModelEndpoint { get; set; } = string.Empty;
    public string VisionModelEndpoint { get; set; } = string.Empty;
}