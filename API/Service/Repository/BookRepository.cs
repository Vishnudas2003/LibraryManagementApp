using API.Model.Book;
using API.Service.Interface.Repository;
using Data.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Service.Repository;

public class BookRepository(ApplicationDbContext dbContext) : IBookRepository
{
    public async Task<List<BookRequest>> GetAllBooksAsync()
    {
        return await dbContext.Book!
            .Where(b => b.StatusId != 0 && !b.IsDeleted)
            .Select(b => new BookRequest
            {
                Title = b.Title,
                Isbn = b.Isbn,
                PublicationDate = b.PublicationDateT.ToShortDateString(),
                Quantity = b.Quantity,
                Author = new[] { $"{b.Author!.FirstName} {b.Author.LastName}" },
                Publisher = b.Publisher!.Name,
                Genre = new[] { b.Genre.Name }
            })
            .ToListAsync();
    }
}