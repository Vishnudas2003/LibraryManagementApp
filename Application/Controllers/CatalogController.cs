using Core.Models.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Services.Catalog;

namespace Application.Controllers;

public class CatalogController : Controller
{
    private readonly IBookService _bookService;

    public CatalogController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var books = await _bookService.GetBooksAsync();
        return View(books);
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index(BookFilter bookFilter)
    {
        var books = await _bookService.GetBooksAsync(bookFilter);
        return View(books);
    }

    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> AddBook()
    {
        
    }
}