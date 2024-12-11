namespace Domain.Interfaces;

public interface IRepository<T>
{
    Task<T> GetByIdAsync(int id);
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<IEnumerable<T>> SearchAsync(string query);
}
