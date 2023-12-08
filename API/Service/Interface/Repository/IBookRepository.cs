using API.Model.Book;

namespace API.Service.Interface.Repository;

public interface IBookRepository
{
    Task<List<BookRequest>> GetAllBooksAsync();
}