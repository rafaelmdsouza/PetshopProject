using Petshop.Domain.Core.Data;
using Petshop.Domain.Core.Model;

namespace Petshop.Infrastructure.Repository;

public class Repository<T, TKey> : IRepository<T, TKey> where T:class, IAggregateRoot
{
    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(TKey id, T entity)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetByIdAsync(TKey id)
    {
        throw new NotImplementedException();
    }

    public void Update(TKey id, T entity)
    {
        throw new NotImplementedException();
    }
}