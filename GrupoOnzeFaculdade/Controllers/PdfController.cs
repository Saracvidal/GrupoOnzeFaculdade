using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.IO;

public class PdfController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public PdfController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    // Ação para servir o PDF
    public IActionResult ViewPdf(string fileName)
    {
        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "pdf", fileName);
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }
        byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
        return File(fileBytes, "application/pdf");
    }

    // Ação para exibir a view que contém o iframe
    public IActionResult Pdf()
    {
        return View();
    }
}