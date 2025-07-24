using System.Text.RegularExpressions;
using ElegenAI.API.Captions.Models;

namespace ElegenAI.API.Captions.Helpers;

public static class ImageHelper
{
    private static readonly Regex DataUriPattern = new(
        @"^data:(?<mime>.+?);base64,(?<data>.+)$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);

    public static bool TryParseBase64Image(string input, out ImageData imageData)
    {
        imageData = null!;

        if (string.IsNullOrWhiteSpace(input))
            return false;

        string mimeType = "image/png"; // Default fallback
        string base64Data = input;

        try
        {
            if (DataUriPattern.IsMatch(input))
            {
                var match = DataUriPattern.Match(input);
                mimeType = match.Groups["mime"].Value;
                base64Data = match.Groups["data"].Value;
            }

            byte[] bytes = Convert.FromBase64String(base64Data);

            imageData = new ImageData
            {
                MimeType = mimeType,
                Bytes = bytes
            };

            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}