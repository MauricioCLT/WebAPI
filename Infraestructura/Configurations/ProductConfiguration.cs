using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.HasKey(x => x.Id);

        entity.Property(x => x.ProductName)
            .IsRequired();

        entity.Property(x => x.Status)
            .IsRequired();

        entity.Property(x => x.ProductDescription)
            .IsRequired();

        entity.Property(x => x.StartDate)
            .IsRequired();

        entity.HasOne(x => x.Entity)
              .WithMany(x => x.Products)
              .HasForeignKey(x => x.EntityId);
    }
}
