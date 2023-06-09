namespace Petshop.Infrastructure.Queries.Processor;

public interface IOwnerQueriesProcessor
{
Task<IEnumerable<T>> GetAllAsync<T>();
Task<IEnumerable<T>> ExecuteQuery<T>(string query, object? param = null);
Task<T> GetById<T>(Guid id);
}
