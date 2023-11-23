using Core.Constants;
using Core.Enums;
using Core.Models.Catalog;
using Core.Models.Catalog.VM;
using Core.Models.Shared;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Repository;
using Services.Interfaces.Services.Catalog;

namespace Services.Services.Catalog;

public class BookService : IBookService
{
    private readonly IGenericRepository<Book> _bookGenericRepository;
    private readonly ApplicationDbContext _applicationDbContext;

    public BookService(IGenericRepository<Book> bookRepository, ApplicationDbContext applicationDbContext)
    {
        _bookGenericRepository = bookRepository;
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        book.Id = Guid.NewGuid().ToString();
        book.CreatedDateT = DateTime.Now;
        book.StatusId = (int)Status.Active;
        book.IsDeleted = false;

        var result = await _applicationDbContext.Book.AddAsync(book);
        await _applicationDbContext.SaveChangesAsync();

        return book;
    }

    public async Task DeleteBookAsync(string id)
    {
        var book = await _applicationDbContext.Book
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();
        
        if (book != null)
        {
            await _bookGenericRepository.DeleteAsync(book);
        }
    }

    public async Task<BookDetailViewModel> GetBookDetailsAsync(string id)
    {
        var bookDetailViewModel = new BookDetailViewModel
        {
            Book = await _applicationDbContext.Book
                .Include(e => e.Loans)
                .Include(e => e.Reservations)
                .Include(e => e.Author).ThenInclude(e => e.Books)
                .Include(e => e.Publisher).ThenInclude(e => e.Books)
                .Include(e => e.Genre).ThenInclude(e => e.Books)
                .FirstOrDefaultAsync()
        };

        return bookDetailViewModel;
    }

    public async Task<Book> EditBookAsync(Book book)
    {
        var result = _applicationDbContext.Book.Update(book);
        await _applicationDbContext.SaveChangesAsync();
        if (result.State == EntityState.Modified)
        {
            book.AlertViewModel.IsSuccess = true;
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