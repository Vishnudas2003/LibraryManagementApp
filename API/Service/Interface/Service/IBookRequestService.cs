using API.Model.Book;

namespace API.Service.Interface.Service;

public interface IBookRequestService
{
    Task<List<BookRequest>> GetBooksAsync();
    Task<BookRequest> GetBookDetailsByIsbnAsync(string? isbn);
}