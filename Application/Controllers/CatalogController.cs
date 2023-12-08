using Core.Models.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interface.Service.Catalog;

namespace Application.Controllers;

public class CatalogController(ICatalogService catalogService) : Controller
{
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var catalogViewModel = await catalogService.GetBooksAsync(User);
        
        return View(catalogViewModel);
    }

    [AllowAnonymous]
    public async Task<IActionResult> FilterBooks(BookFilter bookFilter)
    {
        var catalogViewModel = await catalogService.GetBooksAsync(bookFilter, User);
        return View("Index", catalogViewModel);
    }
}