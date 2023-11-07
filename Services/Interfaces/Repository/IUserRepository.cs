using Core.Models.Account;

namespace Services.Interfaces.Repository;

public interface IUserRepository<T>
{
    Task<bool> UpdateAsync(ApplicationUser entity);
    Task DeleteAsync(ApplicationUser entity);
    ApplicationUser? GetById(string id);
    IEnumerable<ApplicationUser> GetAll();
}