using Core.Models.Catalog;

namespace Services.Interfaces.Services.Catalog;

public interface IBookService
{
    Task<Book> AddBookAsync(Book book);
    Task DeleteBookAsync(Book book);
    Book GetBookDetails(string id);
}