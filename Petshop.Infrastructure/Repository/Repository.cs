using Microsoft.EntityFrameworkCore;
using Petshop.Domain.Core.Data;
using Petshop.Domain.Core.Model;

namespace Petshop.Infrastructure.Repository;

public class Repository<T, TKey> : IRepository<T, TKey> where T : class, IAggregateRoot
{
    private readonly DbContext _dbContext;

    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> GetByIdAsync(TKey id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }
    public async Task Add(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
    public async Task Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }

}