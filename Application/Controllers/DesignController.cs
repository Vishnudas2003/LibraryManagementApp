using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

public class DesignController : Controller
{
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }    
    
    [AllowAnonymous]
    public IActionResult Buttons()
    {
        return View();
    }

    [AllowAnonymous]
    public IActionResult Alerts()
    {
        return View();
    }
}