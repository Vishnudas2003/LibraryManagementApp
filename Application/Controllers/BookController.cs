using Core.Models.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Services.Catalog;

namespace Application.Controllers;

public class BookController : Controller
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public IActionResult Add()
    {
        return View(new Book());
    }
    
    [HttpPost]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public IActionResult Add(Book book)
    public async Task<IActionResult> Add(Book book)
    {
        var result = await _bookService.AddBookAsync(book);

        if (string.IsNullOrWhiteSpace(result.Id))
        {
            return View(book);
        }

        return RedirectToAction(nameof(Details), new { id = book.Id });
    }
    
    [HttpGet]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public IActionResult Delete()
    {
        return View(new Book());
    }
    
    [HttpPost]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public IActionResult Delete(Book book)
    {
        return View(book);
    }
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Details(string id)
    {
        return View(_bookService.GetBookDetails(id));
    }
}