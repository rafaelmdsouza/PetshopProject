using Petshop.Domain.Agreggate.EmployeeAggregate;
using Petshop.Domain.Agreggate.OwnerAggregate;
using Petshop.Infrastructure.Repository;

namespace Microsoft.Extensions.DependencyInjection;
public static class DepencencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddTransient<IOwnerRepository, OwnerRepository>();
        service.AddTransient<IEmployeeRepository, EmployeeRepository>();
        return service;
    }
}