using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations;

public class EntityCustomerConfiguration : IEntityTypeConfiguration<EntityCustomer>
{
    public void Configure(EntityTypeBuilder<EntityCustomer> entity)
    {
        entity.HasKey(e => e.Id);

        entity.HasOne(e => e.Customer)
              .WithMany(e => e.EntityCustomers)
              .HasForeignKey(e => e.CustomerId);

        entity.HasOne(e => e.Entity)
              .WithMany(e => e.EntityCustomers)
              .HasForeignKey(e => e.EntityId);
    }
}
