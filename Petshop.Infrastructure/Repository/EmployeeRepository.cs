using Petshop.Domain.Agreggate.EmployeeAggregate;

namespace Petshop.Infrastructure.Repository;

public class EmployeeRepository : Repository<Employee, Guid>, IEmployeeRepository
{
}