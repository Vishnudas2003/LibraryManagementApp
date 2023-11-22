using Data.Data;
using Services.Interfaces.Repository;

namespace Services.Repository;

public class CatalogRepository : ICatalogRepository
{
    private readonly ApplicationDbContext _context;

    public CatalogRepository(ApplicationDbContext context)
    {
        _context = context;
    }
}