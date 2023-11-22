using Core.Models.Catalog;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Repository;

namespace Services.Repository;

public class CatalogRepository : ICatalogRepository
{
    private readonly ApplicationDbContext _context;

    public CatalogRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetBooksByFilter(BookFilter bookFilter)
    {
        IEnumerable<Book> books = await _context.Book.ToListAsync();
        Author? author;
        Publisher? publisher;
        Genre? genre;

        if (string.IsNullOrWhiteSpace(bookFilter.AuthorFirstName) ||
            string.IsNullOrWhiteSpace(bookFilter.AuthorLastName))
        {
            var authors = _context.Author.ToList();

            author = authors.FirstOrDefault(e =>
                e.FirstName.Contains(bookFilter.AuthorFirstName ?? string.Empty) ||
                e.LastName.Contains(bookFilter.AuthorLastName ?? string.Empty));

            if (author == null)
            {
                // TODO: Return error.
            }

            books = books.Where(e => e.Author.Id == author!.Id).ToList();
        }

        if (string.IsNullOrWhiteSpace(bookFilter.Publisher))
        {
            var publishers = _context.Publisher.ToList();

            publisher = publishers.FirstOrDefault(e =>
                e.Name.Contains(bookFilter.Publisher ?? string.Empty));

            if (publisher == null)
            {
                // TODO: Return error.
            }

            books = books.Where(e => e.Publisher.Id == publisher!.Id).ToList();
        }

        if (string.IsNullOrWhiteSpace(bookFilter.Genre))
        {
            var genres = _context.Genre.ToList();

            genre = genres.FirstOrDefault(e =>
                e.Name.Contains(bookFilter.Genre ?? string.Empty));

            if (genre == null)
            {
                // TODO: Return error.
            }

            books = books.Where(e => e.Genre.Id == genre!.Id).ToList();
        }

        if (string.IsNullOrWhiteSpace(bookFilter.Isbn))
        {
            books = books.Where(e => e.Isbn.Contains(bookFilter.Isbn!));
        }

        if (string.IsNullOrWhiteSpace(bookFilter.Title))
        {
            books = books.Where(e => e.Title.Contains(bookFilter.Title!));
        }

        if (bookFilter.PublicationStartDateT != null)
        {
            books = books.Where(e => e.PublicationDateT > bookFilter.PublicationStartDateT);
        }

        if (bookFilter.PublicationEndDateT != null)
        {
            books = books.Where(e => e.PublicationDateT < bookFilter.PublicationEndDateT);
        }

        if (bookFilter.Quantity != null)
        {
            books = books.Where(e => e.Quantity >= bookFilter.Quantity);
        }

        return books.ToList();
    }
}