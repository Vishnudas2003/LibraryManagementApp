using System.Security.Claims;
using Core.Models.Catalog;
using Core.Models.Catalog.VM;

namespace Services.Interface.Service.Catalog;

public interface IBookService
{
    Task<Book> GenerateNewBookViewAsync();
    bool CheckIsbnExists(string? bookIsbn);
    Task<Book> AddBookAsync(Book book, bool isFromApi = false);
    Task DeleteBookAsync(string id);
    Task<BookDetailViewModel> GetBookDetailsAsync(string id, ClaimsPrincipal claimsPrincipal);
    Task<Book> EditBookAsync(Book book);
}