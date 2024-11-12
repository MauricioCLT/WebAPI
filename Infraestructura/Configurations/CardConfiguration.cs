using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> entity)
    {
        entity.HasKey(x => x.CardId);

        entity.Property(x => x.CustomerId)
              .IsRequired();

        entity.Property(x => x.CardNumber)
            .IsRequired();

        entity.Property(x => x.CardType)
            .IsRequired();

        entity.Property(x => x.CreditLimit)
            .IsRequired();

        entity.Property(x => x.AvailableCredit)
            .IsRequired();

        entity.Property(x => x.Status)
            .IsRequired();

        entity.Property(x => x.ExpirationDate)
            .IsRequired();

        entity.Property(x => x.InterestRate)
            .IsRequired();

        entity.HasOne(x => x.Customer)
            .WithMany(x => x.Cards)
            .HasForeignKey(x => x.CustomerId);
    }
}
