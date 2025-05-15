using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TextractWebApp.Models;
using Amazon.Textract;
using Amazon.Textract.Model;

namespace TextractWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAmazonTextract _textractClient;

    public HomeController(ILogger<HomeController> logger, IAmazonTextract textractClient)
    {
        _logger = logger;
        _textractClient = textractClient;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(DocumentViewModel model)
    {
        if (!ModelState.IsValid || model.Document == null)
            return View("Index", model);

        try
        {
            using var stream = model.Document.OpenReadStream();
            var request = new DetectDocumentTextRequest
            {
                Document = new Document
                {
                    Bytes = new MemoryStream()
                }
            };

            await stream.CopyToAsync(request.Document.Bytes);
            request.Document.Bytes.Position = 0;

            var response = await _textractClient.DetectDocumentTextAsync(request);
            model.ExtractedText = response.Blocks
                .Where(b => b.BlockType == BlockType.LINE)
                .Select(b => b.Text)
                .ToList();

            return View("Result", model);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing document");
            ModelState.AddModelError("", "Error processing document. Please try again.");
            return View("Index", model);
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
