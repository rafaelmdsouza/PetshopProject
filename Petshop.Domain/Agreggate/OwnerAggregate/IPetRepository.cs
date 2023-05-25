using Petshop.Domain.Core.Data;

namespace Petshop.Domain.Agreggate.OwnerAggregate;
public interface IPetRepository : IRepository<Pet, Guid>
{
    
}