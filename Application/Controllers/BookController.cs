using Core.Models.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Services.Catalog;

namespace Application.Controllers;

public class BookController : Controller
{
    private readonly IBookService _bookService;
    private readonly Services.Interfaces.Services.Authorization.IAuthorizationService _authorizationService;

    public BookController(IBookService bookService, Services.Interfaces.Services.Authorization.IAuthorizationService authorizationService)
    {
        _bookService = bookService;
        _authorizationService = authorizationService;
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

        return RedirectToAction(nameof(Detail), new { id = book.Id });
    }
    
    [HttpGet]
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
        return View(_bookService.GetBookDetailsAsync(id));
    }
    
    [HttpPost]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public async Task<IActionResult> Edit(Book book)
    {
        var updatedBook = await _bookService.EditBookAsync(book);

        if (string.IsNullOrWhiteSpace(updatedBook.AlertViewModel.Message))
        {
            return RedirectToAction(nameof(Detail), new { id = book.Id });
        }

        return View(book);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Detail(string id)
    {
        var bookDetailViewModel = await _bookService.GetBookDetailsAsync(id);
        bookDetailViewModel.IsEmployee = _authorizationService.IsEmployee(User);
        
        return View(bookDetailViewModel);
    }
}