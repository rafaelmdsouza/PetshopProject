namespace Petshop.Domain.Agreggate.OwnerAggregate;

public interface IOwnerQueries
{
    Task<IEnumerable<Owner>> GetAllAsync();
    Task<Owner> GetById(Guid id);
}