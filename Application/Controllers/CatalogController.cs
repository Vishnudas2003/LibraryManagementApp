using Core.Models.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Services.Catalog;

namespace Application.Controllers;

public class CatalogController : Controller
{
    private readonly ICatalogService _catalogService;
    private readonly Services.Interfaces.Services.Authorization.IAuthorizationService _authorizationService;

    public CatalogController(ICatalogService catalogService, Services.Interfaces.Services.Authorization.IAuthorizationService authorizationService)
    {
        _catalogService = catalogService;
        _authorizationService = authorizationService;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var catalogViewModel = await _catalogService.GetBooksAsync();
        catalogViewModel.IsEmployee = _authorizationService.IsEmployee(User);
        
        return View(catalogViewModel);
    }

    [AllowAnonymous]
    public async Task<IActionResult> FilterBooks(BookFilter bookFilter)
    {
        var catalogViewModel = await _catalogService.GetBooksAsync(bookFilter);
        catalogViewModel.IsEmployee = _authorizationService.IsEmployee(User);
        catalogViewModel.BookFilter = bookFilter;
        return View("Index", catalogViewModel);
    }
}