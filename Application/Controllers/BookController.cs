using Core.Models.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interface.Service.Catalog;

namespace Application.Controllers;

public class BookController(IBookService bookService, ICatalogService catalogService) : Controller
{
    [HttpGet]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public async Task<IActionResult> Add()
    {
        var book = await bookService.GenerateNewBookViewAsync();
        return View(book);
    }

    [HttpPost]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public async Task<IActionResult> Add(Book book)
    {
        var result = await bookService.AddBookAsync(book);

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
        await bookService.DeleteBookAsync(id);
        ViewBag.SuccessMessage = "Book deleted successfully!";
        return RedirectToAction(nameof(Index), "Catalog");
    }

    [HttpGet]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public async Task<IActionResult> Edit(string id)
    {
        var bookDetailViewModel = await bookService.GetBookDetailsAsync(id, User);
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

        var updatedBook = await bookService.EditBookAsync(book);

        if (!string.IsNullOrWhiteSpace(updatedBook.AlertViewModel.Message)) return View(book);

        ViewBag.SuccessMessage = "Book updated successfully!";
        return RedirectToAction(nameof(Detail), new { id = book.Id });
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Detail(string id)
    {
        var bookDetailViewModel = await bookService.GetBookDetailsAsync(id, User);
        return View(bookDetailViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> GetGenres(string q)
    {
        var allGenres = await catalogService.GetGenresAsync();
        var filteredGenres = string.IsNullOrEmpty(q)
            ? allGenres
            : allGenres.Where(g => g.Name.ToLower().Contains(q.ToLower()));

        var limitedGenres = filteredGenres
            .Take(10)
            .Select(g => new { id = g.Id, text = g.Name })
            .ToList();

        return Ok(limitedGenres);
    }
}