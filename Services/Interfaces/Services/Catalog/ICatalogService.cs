using System.Security.Claims;
using Core.Models.Catalog;
using Core.Models.Catalog.VM;

namespace Services.Interfaces.Services.Catalog;

public interface ICatalogService
{
    Task<CatalogViewModel> GetBooksAsync(ClaimsPrincipal claimsPrincipal);
    Task<CatalogViewModel> GetBooksAsync(BookFilter bookFilter, ClaimsPrincipal claimsPrincipal);
}