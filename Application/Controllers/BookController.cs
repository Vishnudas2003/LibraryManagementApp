using API.Service.Interface.Service;
using Core.Models.Catalog;
using Core.Models.Catalog.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interface.Service.Catalog;

namespace Application.Controllers;

public class BookController(IBookService bookService, ICatalogService catalogService,
    IBookRequestService bookRequestService) : Controller
{
    [HttpGet]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public async Task<IActionResult> Add()
    {
        var addBookVm = new AddBookVm
        {
            Book = await bookService.GenerateNewBookViewAsync()
        };

        return View(addBookVm);
    }

    [HttpPost]
    [Authorize(Roles = "Librarian, AssistantLibrarian, Administrator")]
    public async Task<IActionResult> Add(AddBookVm book)
    {
        var isbnExists = bookService.CheckIsbnExists(book.Isbn);

        if (isbnExists)
        {
            if (book.AlertViewModel != null)
            {
                book.AlertViewModel.IsSuccess = false;
                book.AlertViewModel.Message = "ISBN already exists";
            }

            return View(book);
        }

        var requestedBook = await bookRequestService.GetBookDetailsByIsbnAsync(book.Isbn);

        var populatedBook = new Book
        {
            Author = new Author { Name = requestedBook.Author?[0] },
            Publisher = new Publisher { Name = requestedBook.Publisher ?? string.Empty },
            Isbn = requestedBook.Isbn,
            Title = requestedBook.Title,
            Subtitle = requestedBook.SubTitle,
            PrintType = requestedBook.PrintType,
            PublicationDateT = Convert.ToDateTime(requestedBook.PublicationDate),
            Quantity = book.Quantity,
            PageCount = requestedBook.PageCount,
            Genre = new Genre { Name = requestedBook.Genre?[0] ?? string.Empty }
        };
        
        var result = await bookService.AddBookAsync(populatedBook, true);

        if (string.IsNullOrWhiteSpace(result.Id))
        {
            var addBookVm = new AddBookVm
            {
                Isbn = book.Isbn,
                Quantity = book.Quantity,
                Book = populatedBook
            };
            return View(addBookVm);
        }

        ViewBag.SuccessMessage = "Book added successfully!";
        return RedirectToAction(nameof(Detail), new { id = result.Id });
    }

    public async Task<IActionResult> AddManually(Book book)
    {
        var result = await bookService.AddBookAsync(book);

        if (string.IsNullOrWhiteSpace(result.Id))
        {
            var addBookVm = new AddBookVm
            {
                Book = book
            };
            
            return View(nameof(Add), addBookVm);
        }

        ViewBag.SuccessMessage = "Book added successfully!";
        return RedirectToAction(nameof(Detail), new { id = result.Id });
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