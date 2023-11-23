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

    public async Task<Book> AddBookAsync(Book book)
    {
        book.Id = Guid.NewGuid().ToString();
        book.CreatedDateT = DateTime.UtcNow;
        book.StatusId = (int)Status.Active;
        book.IsDeleted = false;

        await _applicationDbContext.Book.AddAsync(book);
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
