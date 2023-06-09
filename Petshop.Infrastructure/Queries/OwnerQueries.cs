using Petshop.Domain.Agreggate.OwnerAggregate;
using Petshop.Infrastructure.Queries.Processor;
using Petshop.Infrastructure.Queries.Resources;

namespace Petshop.Infrastructure.Queries;

public class OwnerQueries : IOwnerQueries
{
    private readonly IOwnerQueriesProcessor _dataReader;

    public OwnerQueries(IOwnerQueriesProcessor dataReader)
    {
        _dataReader = dataReader;
    }

    public async Task<IEnumerable<Owner>> GetAllAsync()
    {
        var data = await _dataReader.GetAllAsync<Owner>().ConfigureAwait(false);
        return data;
    }

    public async Task<Owner> GetById(Guid id)
    {
        var result = await _dataReader.GetById<Owner>(id).ConfigureAwait(false);
        return result;
    }
}