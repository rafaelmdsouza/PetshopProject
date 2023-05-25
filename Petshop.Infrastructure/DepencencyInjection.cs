using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Petshop.Domain.Agreggate.EmployeeAggregate;
using Petshop.Domain.Agreggate.OwnerAggregate;
using Petshop.Domain.Core.Data;
using Petshop.Infrastructure.Configuration;
using Petshop.Infrastructure.Repository;

namespace Microsoft.Extensions.DependencyInjection;
public static class DepencencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddTransient<IOwnerRepository, OwnerRepository>();
        service.AddTransient<IEmployeeRepository, EmployeeRepository>();
        service.AddTransient<IPetRepository, PetRepository>();

        service.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

                service.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        return service;
    }
}