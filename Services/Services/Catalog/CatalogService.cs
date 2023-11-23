using Core.Models.Catalog;
using Core.Models.Catalog.VM;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Services.Catalog;
using System.Linq.Expressions;

namespace Services.Services.Catalog;

public class CatalogService : ICatalogService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public CatalogService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
    }

    public async Task<CatalogViewModel> GetBooksAsync()
    {
        var booksQuery = ApplyCommonIncludes(_applicationDbContext.Book);

        CatalogViewModel catalogViewModel = new()
        {
            Books = await booksQuery
                .Where(e=> e.IsDeleted == false || e.StatusId != 0)
                .ToListAsync()
        };

        return catalogViewModel;
    }

    public async Task<CatalogViewModel> GetBooksAsync(BookFilter bookFilter)
    {
        var booksQuery = ApplyCommonIncludes(_applicationDbContext.Book);

        if (!string.IsNullOrEmpty(bookFilter.AuthorFirstName) || !string.IsNullOrEmpty(bookFilter.AuthorLastName))
        {
            booksQuery = ApplyFilter(booksQuery, b =>
                b.Author.FirstName.Contains(bookFilter.AuthorFirstName ?? string.Empty) ||
                b.Author.LastName.Contains(bookFilter.AuthorLastName ?? string.Empty));
        }

        if (!string.IsNullOrEmpty(bookFilter.Publisher))
        {
            booksQuery = ApplyFilter(booksQuery, b => b.Publisher.Name.Contains(bookFilter.Publisher));
        }

        if (!string.IsNullOrEmpty(bookFilter.Genre))
        {
            booksQuery = ApplyFilter(booksQuery, b => b.Genre.Name.Contains(bookFilter.Genre));
        }

        if (!string.IsNullOrEmpty(bookFilter.Isbn))
        {
            booksQuery = ApplyFilter(booksQuery, b => b.Isbn.Contains(bookFilter.Isbn));
        }

        if (!string.IsNullOrEmpty(bookFilter.Title))
        {
            booksQuery = ApplyFilter(booksQuery, b => b.Title.Contains(bookFilter.Title));
        }

        if (bookFilter.PublicationStartDateT != null)
        {
            booksQuery = ApplyFilter(booksQuery, b => b.PublicationDateT >= bookFilter.PublicationStartDateT);
        }

        if (bookFilter.PublicationEndDateT != null)
        {
            booksQuery = ApplyFilter(booksQuery, b => b.PublicationDateT <= bookFilter.PublicationEndDateT);
        }

        if (bookFilter.Quantity != null)
        {
            booksQuery = ApplyFilter(booksQuery, b => b.Quantity >= bookFilter.Quantity);
        }

        CatalogViewModel catalogViewModel = new()
        {
            Books = await booksQuery.ToListAsync()
        };

        return catalogViewModel;
    }

    private IQueryable<Book> ApplyCommonIncludes(IEnumerable<Book> query)
    {
        return query.AsQueryable().Where(e => e.StatusId != 0 && e.IsDeleted == false)
            .Include(e => e.Publisher).Where(e => e.StatusId != 0 && e.IsDeleted == false)
            .Include(e => e.Author).Where(e => e.StatusId != 0 && e.IsDeleted == false)
            .Include(e => e.Genre).Where(e => e.StatusId != 0 && e.IsDeleted == false);
    }

    private IQueryable<Book> ApplyFilter(IQueryable<Book> query, Expression<Func<Book, bool>> filter)
    {
        return query.Where(filter);
    }
}