using Data.Data;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces.Repository;

namespace Services.Repository;

public class RoleRepository<T> : IRoleRepository where T : IdentityRole
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task DeleteAsync(IdentityRole entity)
    {
        if (entity == null) throw new InvalidOperationException("Cannot delete a null object!");
        //We do a soft delete, just update it.
        await UpdateAsync(entity);
    }

    public async Task<IdentityRole> UpdateAsync(IdentityRole entity)
    {
        if (entity == null) throw new InvalidOperationException("Cannot update a null object!");

        var role = _context.Roles
            .FirstOrDefault(s => s.Id.Equals(entity.Id));

        if (role != null)
        {
            role.Name = entity.Name;
            role.NormalizedName = entity.Name?.ToUpper();
        }

        await _context.SaveChangesAsync();
        
        return entity;
    }

    public IdentityRole? GetById(string id)
    {
        //Weirdness with async methods here, just use sync.
        var ent = _context.Find<IdentityRole>(id);
        return ent ?? null;
    }

    public IEnumerable<IdentityRole> GetAllForUser(string id)
    {
        return _context.Set<IdentityRole>().Where(e => e.Id == id).ToList();
    }

    public IEnumerable<IdentityRole> GetAll()
    {
        return _context.Set<IdentityRole>().ToList();
    }
}