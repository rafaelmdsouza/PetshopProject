using Petshop.Domain.Agreggate.OwnerAggregate;

namespace Petshop.Infrastructure.Repository;

public class OwnerRepository : Repository<Owner,Guid>, IOwnerRepository
{
}