using Microsoft.AspNetCore.Mvc;

namespace mikolo.Controllers.PDF;

public class PdfController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}