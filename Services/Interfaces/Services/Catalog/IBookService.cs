namespace Services.Interfaces.Services.Catalog;

public interface IBookService
{
    Task<Book> AddBookAsync(Book book);
    Book GetBookDetails(string id);
}