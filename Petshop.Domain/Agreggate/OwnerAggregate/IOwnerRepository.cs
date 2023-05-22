using Petshop.Domain.Core.Data;

namespace Petshop.Domain.Agreggate.OwnerAggregate;

public interface IOwnerRepository : IRepository<Owner, Guid>
{
}