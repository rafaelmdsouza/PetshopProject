using Petshop.Domain.Agreggate.EmployeeAggregate;
using Petshop.Infrastructure.Configuration;

namespace Petshop.Infrastructure.Repository;

public class EmployeeRepository : Repository<Employee,Guid>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext context)
    : base(context)
    {
    }
}