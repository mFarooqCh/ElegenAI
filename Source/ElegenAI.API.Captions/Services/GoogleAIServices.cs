using ElegenAI.API.Captions.Common;
using ElegenAI.API.Captions.Models;
using System.Text;
using System.Text.Json;

namespace ElegenAI.API.Captions.Services;

public sealed class GoogleAiServices : IAiService
{
    private readonly GoogleAIAPISettings _settings = AppEnvironment.GoogleAiApiSettings;
    private readonly HttpClient _httpClient = new();

    public async Task<string?> GenerateContentFromTextAsync(string prompt)
    {
        var request = new GeminiRequest
        {
            SystemInstructions = new Content
            {
                Role = "user",
                Parts = new List<ContentPart>
                {
                    new ()
                    {
                        Text =
@"You are an expert content creator and social media strategist.

Your task is to generate **engaging, catchy, and concise captions** from the input text or keywords. The tone should be modern, impactful, and context-aware — ideal for social media platforms like Instagram, LinkedIn, Twitter/X, or product marketing.

Follow these rules:
1. Keep the caption short and punchy (5–15 words).
2. Use strong verbs and emotional or attention-grabbing language.
3. Avoid generic phrasing. Be clever, witty, or bold — depending on context.
4. If keywords are provided, build a creative hook around them.
5. If context or description is long, summarize the essence into a scroll-stopping phrase.
6. Do **not** repeat the original text verbatim.
7. Add an emoji **only if** it enhances appeal and suits the platform.

Format: Return only the caption text. No explanation or commentary.

If multiple captions are requested, return them as a numbered list.
"
                    }
                }
            },
            Contents = new List<Content>
            {
                new()
                {
                    Role = "user",
                    Parts = new List<ContentPart>
                    {
                        new() { Text =$"Input text: {prompt}" }
                    }
                }
            },
            GenerationConfig = new GenerationConfig()
            {
                MaxOutputTokens = 256,
                Temperature = 1.10F,
                //ThinkingConfig = new ThinkingConfig()
                //{
                //    ThinkingBudget = 256
                //}
            }
        };

        return await SendRequestAsync(_settings.TextModelEndpoint, request);
    }

    public async Task<string?> GenerateContentFromImageAsync(byte[] imageBytes, string mimeType, string prompt)
    {
        var base64Image = Convert.ToBase64String(imageBytes);

        var request = new GeminiRequest
        {
            SystemInstructions = new Content
            {
                Role = "user",
                Parts = new List<ContentPart>
                {
                    new ContentPart()
                    {
                        Text =
@"
You are an expert content creator and visual storyteller.

Your task is to generate engaging, catchy, and context-aware captions or headlines based on the content of an image. The image may include visual elements (e.g., people, objects, colors, mood) and/or text. Additionally, you may receive optional user-provided keywords or context to enhance relevance.

Follow these guidelines:
1. Analyze the image content: Understand the main subject, activity, mood, and any visible text.
2. If additional keywords or user text is provided, creatively incorporate their essence without repeating them directly.
3. Craft a **caption or headline** that is:
   - **Concise** (preferably 5–15 words)
   - **Emotionally or visually aligned** with the image
   - **Scroll-stopping** and suitable for platforms like Instagram, X/Twitter, Facebook, or web banners
4. Be **creative**: Use puns, metaphors, alliteration, or contrast — but only if it enhances the message.
5. Maintain a tone that matches the image style or user intent (e.g., bold, fun, elegant, professional).
6. Do **not** describe the image or explain your response.
7. Emojis are optional — include only if they suit the tone and platform.

Return a single caption or, if asked, a list of 2–5 caption/headline options.

Format: Plain text output. No labels, no markdown.
"
                    }
                }
            },
            Contents = new List<Content>
            {
                new()
                {
                    Role = "user",
                    Parts = new List<ContentPart>
                    {
                        new()
                        {
                            InlineData = new FileData()
                            {
                                MimeType = mimeType,
                                Data = base64Image
                            }
                        }
                    }
                }
            },
            GenerationConfig = new GenerationConfig()
            {
                MaxOutputTokens = 256,
                Temperature = 1.10F,
                ThinkingConfig = new ThinkingConfig()
                {
                    ThinkingBudget = 256
                }
            }
        };

        return await SendRequestAsync(_settings.VisionModelEndpoint, request);
    }

    private async Task<string?> SendRequestAsync(string endpoint, GeminiRequest request)
    {
        var url = $"{endpoint}?key={_settings.ApiKey}";
        var json = JsonSerializer.Serialize(request);
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };

        var response = await _httpClient.SendAsync(httpRequest);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Google AI API Error: {response.StatusCode}\n{error}");
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<GenerateContentResponse>(responseContent);

        return result?.Candidates?.FirstOrDefault()?.Content?.Parts?.FirstOrDefault()?.Text;
    }
}
