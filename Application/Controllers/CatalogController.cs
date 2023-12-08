using Core.Models.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interface.Service.Catalog;

namespace Application.Controllers;

public class CatalogController : Controller
{
    private readonly ICatalogService _catalogService;

    public CatalogController(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var catalogViewModel = await _catalogService.GetBooksAsync(User);
        
        return View(catalogViewModel);
    }

    [AllowAnonymous]
    public async Task<IActionResult> FilterBooks(BookFilter bookFilter)
    {
        var catalogViewModel = await _catalogService.GetBooksAsync(bookFilter, User);
        return View("Index", catalogViewModel);
    }
}