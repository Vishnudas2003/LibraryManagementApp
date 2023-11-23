using System.Security.Claims;
using Core.Constants;
using Microsoft.EntityFrameworkCore;
using Core.Models.Catalog;
using Core.Models.Catalog.VM;
using Core.Models.Shared;
using Data.Data;
using Services.Interfaces.Services.Authorization;
using Services.Interfaces.Services.Catalog;
using Core.Enums;

namespace Services.Services.Catalog;

public class BookService : IBookService
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IAuthorizationService _authorizationService;

    public BookService(ApplicationDbContext applicationDbContext, 
                       IAuthorizationService authorizationService)
    {
        _applicationDbContext = applicationDbContext;
        _authorizationService = authorizationService;
    }

    public async Task<Book> GenerateNewBookViewAsync()
    {
        return new Book
        {
            Genres = await _applicationDbContext.Genre.ToListAsync()
        };
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        var bookExists = _applicationDbContext.Book.Any(e => e.Title == book.Title);
        var ibanExists = _applicationDbContext.Book.Any(e => e.Isbn == book.Isbn);

        if (bookExists)
        {
            book.AlertViewModel.IsSuccess = false;
            book.AlertViewModel.Message = "Book already exists";
        }
        
        if (ibanExists)
        {
            book.AlertViewModel.IsSuccess = false;
            book.AlertViewModel.Message = "Isbn already exists";
        }
        
        book.Id = Guid.NewGuid().ToString();
        book.CreatedDateT = DateTime.UtcNow;
        book.StatusId = (int)Status.Active;
        book.IsDeleted = false;

        // Check if the author exists
        var existingAuthor = _applicationDbContext.Author
            .FirstOrDefault(e => e.FirstName == book.Author.FirstName && e.LastName == book.Author.LastName);
    
        if (existingAuthor != null)
        {
            // If the author exists, use the existing author's Id
            book.AuthorId = existingAuthor.Id;
            book.Author = null; // Detach the new Author object
        }

        // Check if the publisher exists
        var existingPublisher = _applicationDbContext.Publisher
            .FirstOrDefault(e => e.Name == book.Publisher.Name);

        if (existingPublisher != null)
        {
            // If the publisher exists, use the existing publisher's Id
            book.PublisherId = existingPublisher.Id;
            book.Publisher = null; // Detach the new Publisher object
        }

        _applicationDbContext.Book.Add(book);
        await _applicationDbContext.SaveChangesAsync();

        return book;
    }

    public async Task DeleteBookAsync(string id)
    {
        var book = await _applicationDbContext.Book.FindAsync(id);
        if (book != null)
        {
            _applicationDbContext.Book.Remove(book);
            await _applicationDbContext.SaveChangesAsync();
        }
    }

    public async Task<BookDetailViewModel> GetBookDetailsAsync(string id, ClaimsPrincipal claimsPrincipal)
    {
        var book = await _applicationDbContext.Book
            .Include(e => e.Loans)
            .Include(e => e.Reservations)
            .Include(e => e.Author).ThenInclude(e => e.Books)
            .Include(e => e.Publisher).ThenInclude(e => e.Books)
            .Include(e => e.Genre).ThenInclude(e => e.Books)
            .FirstOrDefaultAsync(b => b.Id == id);

        var bookDetailViewModel = new BookDetailViewModel
        {
            Book = book,
            IsEmployee = _authorizationService.IsLibraryStaff(claimsPrincipal)
        };

        return bookDetailViewModel;
    }

    public async Task<Book> EditBookAsync(Book book)
    {
        var existingBook = await _applicationDbContext.Book.FindAsync(book.Id);
        if (existingBook != null)
        {
            _applicationDbContext.Entry(existingBook).CurrentValues.SetValues(book);
            await _applicationDbContext.SaveChangesAsync();

            book.AlertViewModel = new AlertViewModel
            {
                IsSuccess = true
            };
        }
        else
        {
            book.AlertViewModel = new AlertViewModel
            {
                IsSuccess = false,
                Message = StringConstants.BookUpdateFailure
            };
        }

        return book;
    }
}
