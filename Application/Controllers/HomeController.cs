using System.Diagnostics;
using Core.Models.Account;
using Core.Models.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

public class HomeController(ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager)
    : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        if (signInManager.IsSignedIn(User))
        {
            return RedirectToAction(nameof(Index), "Catalog");
        }
        
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Membership()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}