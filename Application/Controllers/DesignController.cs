using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

public class DesignController : Controller
{
    public IActionResult Index()
    {
        return View();
    }    
    
    public IActionResult Buttons()
    {
        return View();
    }

    public IActionResult Alerts()
    {
        return View();
    }
}