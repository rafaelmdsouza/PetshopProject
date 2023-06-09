using Dapper;
using Petshop.Infrastructure.Queries.Core;
using Petshop.Infrastructure.Queries.Resources;

namespace Petshop.Infrastructure.Queries.Processor;

public class OwnerQueriesProcessor : IOwnerQueriesProcessor
{
    private readonly IDbDataProvider _dbDataProvider;
    public OwnerQueriesProcessor(IDbDataProvider dbDataProvider)
    {
        _dbDataProvider = dbDataProvider;
    }
    public async Task<IEnumerable<T>> GetAllAsync<T>()
    {
        Guid? id = null;
        var result = await ExecuteQuery<T>(QueriesResource.OwnerQuery, new {Id = id}).ConfigureAwait(false);
        return result.Cast<T>().ToList();
    }

    public async Task<T> GetById<T>(Guid id)
    {
        var result = await ExecuteQuery<T>(QueriesResource.OwnerQuery, new { Id = id }).ConfigureAwait(false);
        return result.FirstOrDefault();
    }
    public async Task<IEnumerable<T>> ExecuteQuery<T>(string query, object? param = null)
    {
        using var connection = _dbDataProvider.GetConnection();
        connection.Open();
        return await connection.QueryAsync<T>(query, param).ConfigureAwait(false);
    }
}