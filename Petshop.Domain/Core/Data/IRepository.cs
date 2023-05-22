using Petshop.Domain.Core.Model;

namespace Petshop.Domain.Core.Data;

public interface IRepository<T, TKey> where T : class, IAggregateRoot
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(TKey id);
    void Add(T entity);
    void Update(TKey id, T entity);
    void Delete(TKey id, T entity);
}