using Petshop.Domain.Core.Data;

namespace Petshop.Domain.Agreggate.EmployeeAggregate;

public interface IEmployeeRepository : IRepository<Employee, Guid>
{
}