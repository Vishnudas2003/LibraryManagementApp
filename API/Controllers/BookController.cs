using API.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookRequestService _bookService;
    private readonly ILogger<BookController> _logger;
    
    public BookController(IBookRequestService bookService, ILogger<BookController> logger)
    {
        _bookService = bookService;
        _logger = logger;
    }
    
    [HttpGet("GetBooks")]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _bookService.GetBooksAsync();
        return Ok(books);
    }
    
    [HttpGet("GetBookByIsbn")]
    public async Task<IActionResult> GetBooksByIsbn(string isbn)
    {
        var book = await _bookService.GetBookDetailsByIsbnAsync(isbn);
        return Ok(book);
    }
}