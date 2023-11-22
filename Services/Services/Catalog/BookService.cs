using Core.Models.Catalog;
using Services.Interfaces.Repository;
using Services.Interfaces.Services.Catalog;

namespace Services.Services.Catalog;

public class BookService : IBookService
{
    private readonly IGenericRepository<Book> _bookGenericRepository;

    public BookService(IGenericRepository<Book> bookRepository)
    {
        _bookGenericRepository = bookRepository;
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        return await _bookGenericRepository.AddAsync(book);
    }

    public async Task DeleteBookAsync(Book book)
    {
        await _bookGenericRepository.DeleteAsync(book);
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