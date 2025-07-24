using ElegenAI.API.Captions.Helpers;
using ElegenAI.API.Captions.Models;
using ElegenAI.API.Captions.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElegenAI.API.Captions.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CaptionsController(ILogger<CaptionsController> logger, IAiService aiService) : ControllerBase
{
    private readonly ILogger<CaptionsController> _logger = logger;
    private readonly IAiService _aiService = aiService;

    [HttpGet("from-text")]
    public async Task<IActionResult> GetCaptionsAsync([FromQuery] string text)
    {
        _logger.LogInformation("Received new Get Captions From Text request...");
        var responseCaptionText = await _aiService.GenerateContentFromTextAsync(text);
        if (string.IsNullOrEmpty(responseCaptionText))
        {
            _logger.LogWarning("No caption generated from text.");
            return NotFound("No caption generated from the provided text.");
        }
        _logger.LogInformation(responseCaptionText);
        _logger.LogInformation("RESPONSE ENDED");
        return Ok(responseCaptionText);
    }

    [HttpPost("from-image")]
    public async Task<IActionResult> GetCaptionsFromImageAsync(CaptionRequest request)
    {
        _logger.LogInformation("Received new Image-based caption generation request...");

        if (!ImageHelper.TryParseBase64Image(request.ImageBase64, out var imageData))
        {
            _logger.LogWarning("Invalid base64 image input.");
            return BadRequest("Invalid base64 image input.");
        }

        var responseCaptionText = await _aiService.GenerateContentFromImageAsync(imageData.Bytes, imageData.MimeType, request.Text);
        if (string.IsNullOrEmpty(responseCaptionText))
        {
            _logger.LogWarning("No caption generated from Image-based input.");
            return NotFound("No caption generated from Image-based input.");
        }
        _logger.LogInformation(responseCaptionText);
        _logger.LogInformation("RESPONSE ENDED");
        return Ok(responseCaptionText);
    }
}