namespace ElegenAI.API.Captions.Models
{
    public sealed class ImageData
    {
        public string MimeType { get; set; } = string.Empty;
        public byte[] Bytes { get; set; } = [];
    }
}
