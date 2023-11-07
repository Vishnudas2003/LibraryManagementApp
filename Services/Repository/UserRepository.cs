using Core.Enums;
using Core.Models.Account;
using Data.Data;
using Services.Interfaces.Repository;

namespace Services.Repository;

public class UserRepository<T> : IUserRepository<T> where T : ApplicationUser
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task DeleteAsync(ApplicationUser entity)
    {
        if (entity == null) throw new InvalidOperationException("Cannot delete a null object!");
        //We do a soft delete, just update it.
        entity.StatusId = (int)Status.Deleted;
        entity.ModifiedDateT = DateTime.UtcNow;
        await UpdateAsync(entity);
    }

    public async Task<bool> UpdateAsync(ApplicationUser entity)
    {
        if (entity == null) throw new InvalidOperationException("Cannot update a null object!");

        var dbUser = _context.Users
            .FirstOrDefault(s => s.Id.Equals(entity.Id));

        if (dbUser == null) return false;
        
        dbUser.Email = entity.Email;
        dbUser.ModifiedDateT = DateTime.UtcNow;
        dbUser.UserName = entity.UserName;
        dbUser.NormalizedUserName = entity.UserName?.ToUpper();
        dbUser.NormalizedEmail = entity.Email?.ToUpper();
        
        if (dbUser.CreatedDateT == DateTime.MinValue)
        {
            dbUser.CreatedDateT = DateTime.UtcNow;
        }

        _context.Update(dbUser);
        await _context.SaveChangesAsync();
        return true;
    }

    public ApplicationUser? GetById(string id)
    {
        //Weirdness with async methods here, just use sync.
        var ent = _context.Find<T>(id);
        if (ent == null) return null;
        return ent.StatusId == (int)Status.Deleted ? null : ent;
    }

    public IEnumerable<ApplicationUser> GetAll()
    {
        return _context.Set<T>().Where(t => t.StatusId != (int)Status.Deleted).ToList();
    }
}