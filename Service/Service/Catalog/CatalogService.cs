using System.Linq.Expressions;
using System.Security.Claims;
using Core.Enums;
using Core.Models.Catalog;
using Core.Models.Catalog.VM;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Services.Interface.Service.Authorization;
using Services.Interface.Service.Catalog;

namespace Services.Service.Catalog;

public class CatalogService(ApplicationDbContext applicationDbContext, IAuthorizationService authorizationService)
    : ICatalogService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));

    public async Task<CatalogViewModel> GetBooksAsync(ClaimsPrincipal claimsPrincipal)
    {
        var booksQuery = ApplyCommonIncludes(_applicationDbContext.Book);

        CatalogViewModel catalogViewModel = new()
        {
            Books = await booksQuery
                .Where(e=> e.IsDeleted == false || e.Status != Status.Blocked)
                .ToListAsync(),
            IsEmployee = authorizationService.IsLibraryStaff(claimsPrincipal),
            BookFilter = new BookFilter
            {
                Genres = _applicationDbContext.Genre.ToList()
            }
        };

        return catalogViewModel;
    }

    public bool GenreDoesExist(string genre)
    {
        var result = _applicationDbContext.Genre.Any(e => e.Name == genre);
        return result;
    }

    public async Task<CatalogViewModel> GetBooksAsync(BookFilter bookFilter, ClaimsPrincipal claimsPrincipal)
    {
        var booksQuery = ApplyCommonIncludes(_applicationDbContext.Book);

        if (!string.IsNullOrEmpty(bookFilter.AuthorName))
        {
            booksQuery = ApplyFilter(booksQuery, b => b.Author.Name.Contains(bookFilter.AuthorName));
        }

        if (!string.IsNullOrEmpty(bookFilter.Publisher))
        {
            booksQuery = ApplyFilter(booksQuery, b => b.Publisher.Name.Contains(bookFilter.Publisher));
        }

        if (bookFilter.GenreId.HasValue)
        {
            booksQuery = ApplyFilter(booksQuery, b => b.GenreId == bookFilter.GenreId);
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
            booksQuery = ApplyFilter(booksQuery, b => b.Quantity == bookFilter.Quantity);
        }

        CatalogViewModel catalogViewModel = new()
        {
            Books = await booksQuery.ToListAsync(),
            IsEmployee = authorizationService.IsLibraryStaff(claimsPrincipal),
            BookFilter = bookFilter
        };

        bookFilter.Genres = _applicationDbContext.Genre.ToList();
        return catalogViewModel;
    }

    public async Task<List<Genre>> GetGenresAsync()
    {
        return await _applicationDbContext.Genre!
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    private IQueryable<Book> ApplyCommonIncludes(IEnumerable<Book>? query)
    {
        return query!.AsQueryable().Where(e => e.Status != Status.Blocked && e.IsDeleted == false)
            .Include(e => e.Publisher).Where(e => e.Status != Status.Blocked && e.IsDeleted == false)
            .Include(e => e.Author).Where(e => e.Status != Status.Blocked && e.IsDeleted == false)
            .Include(e => e.Genre).Where(e => e.Status != Status.Blocked && e.IsDeleted == false);
    }

    private IQueryable<Book> ApplyFilter(IQueryable<Book> query, Expression<Func<Book, bool>> filter)
    {
        return query.Where(filter);
    }
}