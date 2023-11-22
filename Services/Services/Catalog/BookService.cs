using Core.Models.Catalog;
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
    public BookService(IGenericRepository<Book> bookRepository)
    {
        _bookGenericRepository = bookRepository;
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        return await _bookGenericRepository.AddAsync(book);
    }
    }
}