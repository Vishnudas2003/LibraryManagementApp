using Microsoft.AspNetCore.Identity;

namespace Services.Interface.Repository;

public interface IRoleRepository
{
    Task<IdentityRole> UpdateAsync(IdentityRole entity);
    Task DeleteAsync(IdentityRole entity);
    IdentityRole? GetById(string id);
    IEnumerable<IdentityRole> GetAll();
    IEnumerable<IdentityRole> GetAllForUser(string id);
}