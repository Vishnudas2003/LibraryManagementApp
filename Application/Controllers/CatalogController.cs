using Core.Models.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Services.Catalog;

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
        var books = await _catalogService.GetBooksAsync();
        return View(books);
    }

    [AllowAnonymous]
    public async Task<IActionResult> FilterBooks(BookFilter bookFilter)
    {
        var books = await _catalogService.GetBooksAsync(bookFilter);
        
        //TODO: Add book filter to Book
        return View("Index", books);
    }
}