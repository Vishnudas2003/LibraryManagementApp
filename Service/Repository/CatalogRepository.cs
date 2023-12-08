using Core.Models.Catalog;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Services.Interface.Repository;

namespace Services.Repository;

public class CatalogRepository : ICatalogRepository
{
    private readonly ApplicationDbContext _context;

    public CatalogRepository(ApplicationDbContext context)
    {
        _context = context;
    }
}