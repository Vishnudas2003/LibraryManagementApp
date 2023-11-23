using System.Security.Claims;
using Core.Models.Catalog;
using Core.Models.Catalog.VM;

namespace Services.Interfaces.Services.Catalog;

public interface IBookService
{
    Task<Book> AddBookAsync(Book book);
    Task DeleteBookAsync(string id);
    Task<BookDetailViewModel> GetBookDetailsAsync(string id, ClaimsPrincipal claimsPrincipal);
    Task<Book> EditBookAsync(Book book);
}