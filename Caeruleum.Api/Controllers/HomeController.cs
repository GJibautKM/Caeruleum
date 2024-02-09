using Microsoft.AspNetCore.Mvc;

namespace Caeruleum.Api.Controllers;

[Route("")]
[ApiExplorerSettings(IgnoreApi = true)]
public class HomeController(
    
) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
