using Core.Models.Catalog;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Repository;
using Services.Interfaces.Services.Catalog;

namespace Services.Services.Catalog;

public class CatalogService : ICatalogService
{
    private readonly IGenericRepository<Book> _bookGenericRepository;
    private readonly ApplicationDbContext _applicationDbContext;

    public CatalogService(IGenericRepository<Book> bookRepository, ApplicationDbContext applicationDbContext)
    {
        _bookGenericRepository = bookRepository;
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        return await _applicationDbContext.Book
            .Include(e => e.Publisher)
            .Include(e => e.Author)
            .Include(e => e.Genre)
            .ToListAsync();
    }

    public async Task<List<Book>> GetBooksAsync(BookFilter bookFilter)
    {
        IQueryable<Book> booksQuery = _applicationDbContext.Book;

        booksQuery = ApplyAuthorFilter(booksQuery, bookFilter);
        booksQuery = ApplyPublisherFilter(booksQuery, bookFilter);
        booksQuery = ApplyGenreFilter(booksQuery, bookFilter);
        booksQuery = ApplyIsbnFilter(booksQuery, bookFilter);
        booksQuery = ApplyTitleFilter(booksQuery, bookFilter);
        booksQuery = ApplyPublicationDateFilter(booksQuery, bookFilter);
        booksQuery = ApplyQuantityFilter(booksQuery, bookFilter);

        return await booksQuery.ToListAsync();
    }

    private IQueryable<Book> ApplyAuthorFilter(IQueryable<Book> query, BookFilter filter)
    {
        if (string.IsNullOrEmpty(filter.AuthorFirstName) && string.IsNullOrEmpty(filter.AuthorLastName))
            return query;

        var author = _applicationDbContext.Author.FirstOrDefault(a =>
            a.FirstName.Contains(filter.AuthorFirstName ?? string.Empty) ||
            a.LastName.Contains(filter.AuthorLastName ?? string.Empty));

        if (author == null) throw new Exception("Author not found");

        query = query.Where(b => b.Author.Id == author.Id);

        return query;
    }

    private IQueryable<Book> ApplyPublisherFilter(IQueryable<Book> query, BookFilter filter)
    {
        if (string.IsNullOrEmpty(filter.Publisher))
            return query;

        var publisher = _applicationDbContext.Publisher.FirstOrDefault(p =>
            p.Name.Contains(filter.Publisher));

        if (publisher == null) throw new Exception("Publisher not found");

        query = query.Where(b => b.Publisher.Id == publisher.Id);

        return query;
    }

    private IQueryable<Book> ApplyGenreFilter(IQueryable<Book> query, BookFilter filter)
    {
        if (string.IsNullOrEmpty(filter.Genre))
            return query;

        var genre = _applicationDbContext.Genre.FirstOrDefault(g =>
            g.Name.Contains(filter.Genre));

        if (genre == null) throw new Exception("Genre not found");

        query = query.Where(b => b.Genre.Id == genre.Id);

        return query;
    }

    private IQueryable<Book> ApplyIsbnFilter(IQueryable<Book> query, BookFilter filter)
    {
        if (!string.IsNullOrEmpty(filter.Isbn))
        {
            query = query.Where(b => b.Isbn.Contains(filter.Isbn));
        }

        return query;
    }

    private IQueryable<Book> ApplyTitleFilter(IQueryable<Book> query, BookFilter filter)
    {
        if (!string.IsNullOrEmpty(filter.Title))
        {
            query = query.Where(b => b.Title.Contains(filter.Title));
        }

        return query;
    }

    private IQueryable<Book> ApplyPublicationDateFilter(IQueryable<Book> query, BookFilter filter)
    {
        if (filter.PublicationStartDateT != null)
        {
            query = query.Where(b => b.PublicationDateT >= filter.PublicationStartDateT);
        }

        if (filter.PublicationEndDateT != null)
        {
            query = query.Where(b => b.PublicationDateT <= filter.PublicationEndDateT);
        }

        return query;
    }

    private IQueryable<Book> ApplyQuantityFilter(IQueryable<Book> query, BookFilter filter)
    {
        if (filter.Quantity != null)
        {
            query = query.Where(b => b.Quantity >= filter.Quantity);
        }

        return query;
    }
}