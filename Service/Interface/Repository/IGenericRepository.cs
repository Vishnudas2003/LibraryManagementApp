namespace Services.Interface.Repository;

public interface IGenericRepository<T>
{
    Task<T> AddAsync(T entity);
        
    T Add(T entity);
        
    Task<T> UpdateAsync(T entity);
        
    Task DeleteAsync(T entity);
        
    Task RemoveAsync(T entity);
        
    T? GetById(string id);
    T? GetById(int id);
        
    IEnumerable<T> GetAll();

    Task<List<T>> GetAllAsync();
}