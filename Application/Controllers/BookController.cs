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

        ViewBag.SuccessMessage = "Book added successfully!";
        return RedirectToAction(nameof(Detail), new { id = book.Id });
    }
    
    [HttpGet]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public async Task<IActionResult> Delete(string id)
    {
        await _bookService.DeleteBookAsync(id);
        ViewBag.SuccessMessage = "Book deleted successfully!";
        return RedirectToAction(nameof(Index), "Catalog");
    }
    
    [HttpGet]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public async Task<IActionResult> Edit(string id)
    {
        var bookDetailViewModel = await _bookService.GetBookDetailsAsync(id, User);
        return View(bookDetailViewModel);
    }
    
    [HttpPost]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public async Task<IActionResult> Edit(Book book)
    {
        if (!ModelState.IsValid)
        {
            return View(book);
        }

        var updatedBook = await _bookService.EditBookAsync(book);

        if (!string.IsNullOrWhiteSpace(updatedBook.AlertViewModel.Message)) return View(book);
        
        ViewBag.SuccessMessage = "Book updated successfully!";
        return RedirectToAction(nameof(Detail), new { id = book.Id });
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Detail(string id)
    {
        var bookDetailViewModel = await _bookService.GetBookDetailsAsync(id, User);
        return View(bookDetailViewModel);
    }
}