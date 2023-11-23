using Core.Enums;
using Core.Models.Catalog;
using Data.Data;
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
        var book = _bookGenericRepository.GetById(id);
        
        if (book != null)
        {
            await _bookGenericRepository.DeleteAsync(book);
        }
    }

    public Book GetBookDetails(string id)
    {
        return _bookGenericRepository.GetById(id) ?? new Book();
    }

    public async Task<Book> EditBookAsync(Book book)
    {
        return await _bookGenericRepository.UpdateAsync(book);
    }
}