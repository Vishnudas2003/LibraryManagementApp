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
    public async Task<IActionResult> Add(Book book)
    {
        var result = await _bookService.AddBookAsync(book);

        if (string.IsNullOrWhiteSpace(result.Id))
        {
            return View(book);
        }

        return RedirectToAction(nameof(Details), new { id = book.Id });
    }
    
    [HttpPost]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public async Task<IActionResult> Delete(string id)
    {
        await _bookService.DeleteBookAsync(id);

        return RedirectToAction(nameof(Index), "Catalog");
    }
    
    [HttpGet]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public IActionResult Edit(string id)
    {
        return View(_bookService.GetBookDetails(id));
    }
    
    [HttpPost]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public async Task<IActionResult> Edit(Book book)
    {
        var updatedBook = await _bookService.EditBookAsync(book);
        
        // TODO: Add redirect to edit view if errormessage exists

        return RedirectToAction(nameof(Details), new { id = book.Id });
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Details(string id)
    {
        return View(_bookService.GetBookDetails(id));
    }
}