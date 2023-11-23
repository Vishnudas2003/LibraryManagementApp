using Core.Models.Account;
using Core.Models.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Services.Catalog;

namespace Application.Controllers;

public class CatalogController : Controller
{
    private readonly ICatalogService _catalogService;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public CatalogController(ICatalogService catalogService, SignInManager<ApplicationUser> signInManager)
    {
        _catalogService = catalogService;
        _signInManager = signInManager;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var catalogViewModel = await _catalogService.GetBooksAsync();
        catalogViewModel.IsEmployee = _signInManager.IsSignedIn(User);
        
        return View(catalogViewModel);
    }

    [AllowAnonymous]
    public async Task<IActionResult> FilterBooks(BookFilter bookFilter)
    {
        var catalogViewModel = await _catalogService.GetBooksAsync(bookFilter);
        catalogViewModel.IsEmployee = _signInManager.IsSignedIn(User);
        catalogViewModel.BookFilter = bookFilter;
        return View("Index", catalogViewModel);
    }
}