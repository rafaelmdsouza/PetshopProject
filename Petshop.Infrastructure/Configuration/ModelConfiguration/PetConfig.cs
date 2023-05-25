using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petshop.Domain.Agreggate.OwnerAggregate;

namespace Petshop.Infrastructure.Configuration.ModelConfiguration;

public class PetConfig : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasMany(p => p.History)
        .WithOne()
        .HasForeignKey(ph => ph.PetId);
    }
}