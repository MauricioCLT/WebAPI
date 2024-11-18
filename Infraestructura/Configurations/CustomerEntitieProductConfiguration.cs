using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations;

public class CustomerEntityProductConfiguration : IEntityTypeConfiguration<CustomerEntityProduct>
{
    public void Configure(EntityTypeBuilder<CustomerEntityProduct> entity)
    {
        entity.HasKey(e => e.Id);

        entity.HasOne(x => x.EntityCustomer)
              .WithMany(x => x.CustomersEntitiesProducts)
              .HasForeignKey(x => x.EntityCustomerId);

        entity.HasOne(x => x.Product)
              .WithMany(x => x.CustomersEntitiesProducts)
              .HasForeignKey(x => x.ProductId);
    } 
}
