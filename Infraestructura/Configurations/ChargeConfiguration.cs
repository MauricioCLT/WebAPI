using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations;

public class ChargeConfiguration : IEntityTypeConfiguration<Charge>
{
    public void Configure(EntityTypeBuilder<Charge> entity)
    {
        entity.HasKey(x => x.ChargerId);
        entity.Property(x => x.Amount).IsRequired();
        entity.Property(x => x.Description).IsRequired();
        entity.Property(x => x.Date).IsRequired();

        entity.HasOne(x => x.Card)
              .WithMany(x => x.Charges)
              .HasForeignKey(x => x.CardId);
    }
}
