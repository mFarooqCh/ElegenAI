namespace ElegenAI.API.Captions.Models
{
    public sealed class CaptionRequest
    {
        public string ImageBase64 { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}
