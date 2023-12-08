using API.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController(IBookRequestService bookService, ILogger<BookController> logger)
    : ControllerBase
{
    private readonly ILogger<BookController> _logger = logger;

    [HttpGet("GetBooks")]
    public async Task<IActionResult> GetBooks()
    {
        var books = await bookService.GetBooksAsync();
        return Ok(books);
    }
    
    [HttpGet("GetBookByIsbn")]
    public async Task<IActionResult> GetBooksByIsbn(string isbn)
    {
        var book = await bookService.GetBookDetailsByIsbnAsync(isbn);
        return Ok(book);
    }
}