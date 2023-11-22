using Core.Models.Catalog;

namespace Services.Interfaces.Services.Catalog;

public interface ICatalogService
{
    Task<List<Book>> GetBooksAsync();
    Task<List<Book>> GetBooksAsync(BookFilter bookFilter);
}