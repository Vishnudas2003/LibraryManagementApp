using System.Security.Claims;
using Core.Constants;
using Core.Enums;
using Core.Models.Catalog;
using Core.Models.Catalog.VM;
using Core.Models.Shared;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Services.Interface.Service.Authorization;
using Services.Interface.Service.Catalog;

namespace Services.Service.Catalog;

public class BookService(ApplicationDbContext applicationDbContext,
        IAuthorizationService authorizationService)
    : IBookService
{
    public async Task<Book> GenerateNewBookViewAsync()
    {
        return new Book
        {
            Genres = await (applicationDbContext.Genre ?? throw new InvalidOperationException())
                .ToListAsync()
        };
    }

    public bool CheckIsbnExists(string? bookIsbn)
    {
        return (applicationDbContext.Book ?? throw new InvalidOperationException())
            .Any(e => e.Isbn == bookIsbn);
    }

    private bool CheckTitleExists(string? title)
    {
        return (applicationDbContext.Book ?? throw new InvalidOperationException())
            .Any(e => e.Title == title);
    }

    public async Task<Book> AddBookAsync(Book book, bool isFromApi = false)
    {
        if (IsBookExisting(book))
        {
            SetBookAlert(book, false, "Book already exists");
            return book;
        }

        SetNewBookProperties(book);
        AttachExistingEntities(book, isFromApi);

        applicationDbContext.Book?.Add(book);
        await applicationDbContext.SaveChangesAsync();

        return book;
    }
    
    public async Task DeleteBookAsync(string id)
    {
        if (applicationDbContext.Book != null)
        {
            var book = await applicationDbContext.Book.FindAsync(id);
            if (book != null)
            {
                applicationDbContext.Book.Remove(book);
                await applicationDbContext.SaveChangesAsync();
            }
        }
    }

    public async Task<BookDetailViewModel> GetBookDetailsAsync(string id, ClaimsPrincipal claimsPrincipal)
    {
        var book = await (applicationDbContext.Book ?? throw new InvalidOperationException())
            .Include(e => e.Loans)
            .Include(e => e.Reservations)
            .Include(e => e.Author).ThenInclude(e => e.Books)
            .Include(e => e.Publisher).ThenInclude(e => e.Books)
            .Include(e => e.Genre).ThenInclude(e => e.Books)
            .FirstOrDefaultAsync(b => b.Id == id);

        var bookDetailViewModel = new BookDetailViewModel
        {
            Book = book,
            IsEmployee = authorizationService.IsLibraryStaff(claimsPrincipal)
        };

        return bookDetailViewModel;
    }

    public async Task<Book> EditBookAsync(Book book)
    {
        if (applicationDbContext.Book != null)
        {
            var existingBook = await applicationDbContext.Book.FindAsync(book.Id);
            if (existingBook != null)
            {
                applicationDbContext.Entry(existingBook).CurrentValues.SetValues(book);
                await applicationDbContext.SaveChangesAsync();

                SetBookAlert(book, true, null);
            }
            else
            {
                SetBookAlert(book, false, StringConstants.BookUpdateFailure);
            }
        }

        return book;
    }
    
    private bool IsBookExisting(Book book)
    {
        return CheckIsbnExists(book.Isbn) || CheckTitleExists(book.Title);
    }

    private void SetNewBookProperties(BaseEntity book)
    {
        book.Id = Guid.NewGuid().ToString();
        book.CreatedDateT = DateTime.UtcNow;
        book.Status = Status.Active;
        book.IsDeleted = false;
    }

    private void AttachExistingEntities(Book book, bool isFromApi)
    {
        AttachExistingAuthor(book);
        AttachExistingPublisher(book);
        if (isFromApi)
        {
            AttachExistingGenre(book);
        }
    }

    private void AttachExistingAuthor(Book book)
    {
        var existingAuthor = (applicationDbContext.Author ?? throw new InvalidOperationException())
            .FirstOrDefault(e => book.Author != null && e.Name == book.Author.Name);

        if (existingAuthor != null)
        {
            book.AuthorId = existingAuthor.Id;
            book.Author = null;
        }
    }

    private void AttachExistingPublisher(Book book)
    {
        var existingPublisher = (applicationDbContext.Publisher ?? throw new InvalidOperationException())
            .FirstOrDefault(e => book.Publisher != null && e.Name == book.Publisher.Name);

        if (existingPublisher != null)
        {
            book.PublisherId = existingPublisher.Id;
            book.Publisher = null;
        }
    }

    private void AttachExistingGenre(Book book)
    {
        var existingGenre = (applicationDbContext.Genre ?? throw new InvalidOperationException())
            .FirstOrDefault(e => book.Genre != null && e.Name == book.Genre.Name);

        if (existingGenre != null)
        {
            book.GenreId = existingGenre.Id;
            book.Genre = null;
        }
    }

    private void SetBookAlert(Book book, bool isSuccess, string message)
    {
        book.AlertViewModel.IsSuccess = isSuccess;
        book.AlertViewModel.Message = message;
    }
}