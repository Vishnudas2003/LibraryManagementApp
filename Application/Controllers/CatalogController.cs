using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

public class CatalogController : Controller
{
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }
}