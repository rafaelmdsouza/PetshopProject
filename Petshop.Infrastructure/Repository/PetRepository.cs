using Petshop.Domain.Agreggate.OwnerAggregate;
using Petshop.Infrastructure.Configuration;

namespace Petshop.Infrastructure.Repository;

public class PetRepository : Repository<Pet, Guid>, IPetRepository
{
    public PetRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}