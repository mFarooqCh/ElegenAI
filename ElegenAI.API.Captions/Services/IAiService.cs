namespace ElegenAI.API.Captions.Services;

public interface IAiService
{
    Task<string?> GenerateContentFromTextAsync(string prompt);
    Task<string?> GenerateContentFromImageAsync(byte[] imageBytes, string mimeType, string prompt);
}