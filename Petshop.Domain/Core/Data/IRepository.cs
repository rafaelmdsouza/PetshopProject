using Petshop.Domain.Core.Model;

namespace Petshop.Domain.Core.Data;

public interface IRepository<T, TKey> where T : class, IAggregateRoot
{
    Task<T> GetByIdAsync(TKey id);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}