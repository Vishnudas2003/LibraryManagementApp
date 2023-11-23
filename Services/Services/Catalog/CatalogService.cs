using Core.Models.Catalog;
using Core.Models.Catalog.VM;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Services.Catalog;
using System.Linq.Expressions;
using System.Security.Claims;
using Services.Interfaces.Services.Authorization;

namespace Services.Services.Catalog;

public class CatalogService : ICatalogService
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IAuthorizationService _authorizationService;

    public CatalogService(ApplicationDbContext applicationDbContext, IAuthorizationService authorizationService)
    {
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        _authorizationService = authorizationService;
    }

    public async Task<CatalogViewModel> GetBooksAsync(ClaimsPrincipal claimsPrincipal)
    {
        var booksQuery = ApplyCommonIncludes(_applicationDbContext.Book);

        CatalogViewModel catalogViewModel = new()
        {
            Books = await booksQuery
                .Where(e=> e.IsDeleted == false || e.StatusId != 0)
                .ToListAsync(),
            IsEmployee = _authorizationService.IsLibraryStaff(claimsPrincipal),
            BookFilter = new BookFilter
            {
                Genres = _applicationDbContext.Genre.ToList()
            }
        };

        return catalogViewModel;
    }

    public async Task<CatalogViewModel> GetBooksAsync(BookFilter bookFilter, ClaimsPrincipal claimsPrincipal)
    {
        var booksQuery = ApplyCommonIncludes(_applicationDbContext.Book);

        if (!string.IsNullOrEmpty(bookFilter.AuthorFirstName))
        {
            booksQuery = ApplyFilter(booksQuery, b => b.Author.FirstName.Contains(bookFilter.AuthorFirstName));
        }

        if (!string.IsNullOrEmpty(bookFilter.AuthorLastName))
        {
            booksQuery = ApplyFilter(booksQuery, b => b.Author.LastName.Contains(bookFilter.AuthorLastName));
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
            IsEmployee = _authorizationService.IsLibraryStaff(claimsPrincipal),
            BookFilter = bookFilter
        };

        bookFilter.Genres = _applicationDbContext.Genre.ToList();
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