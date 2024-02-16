using Microsoft.AspNetCore.Mvc;

namespace Caeruleum.Api.Controllers;

[Route("")]
[ApiExplorerSettings(IgnoreApi = true)]
public class HomeController(
    ILogger<HomeController> logger
) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        logger.LogInformation("Showing Home/Index view");
        return View();
    }
}
