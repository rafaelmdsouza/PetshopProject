using Microsoft.EntityFrameworkCore;
using Petshop.Domain.Agreggate.EmployeeAggregate;
using Petshop.Domain.Agreggate.OwnerAggregate;
using Petshop.Infrastructure.Configuration.ModelConfiguration;

namespace Petshop.Infrastructure.Configuration;

public class ApplicationDbContext : DbContext
{
    public DbSet<Owner> Owner { get; set; }
    public DbSet<Pet> Pet { get; set; }
    public DbSet<PetHistory> PetHistory { get; set; }
    public DbSet<Employee> Employee { get; set; }


     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PetConfig());
    }
}