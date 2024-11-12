using Core.DTOs.Card;
using Core.Entities;
using Mapster;

namespace Infraestructura.Mapping;

public class CardMappingConfiguration : IRegister
{
    // 
    public static string GenerateRandomCardNumbers()
    {
        var random = new Random();
        string number = "";

        for (int i = 0; i <= 16; i++)
        {
            number += random.Next(0, 10);
        }

        return number;
    }

    public void Register(TypeAdapterConfig config)
    {
        var random = new Random();

        config.NewConfig<CreateCardDTO, Card>()
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            .Map(dest => dest.CardType, src => src.CardType)
            .Map(dest => dest.CreditLimit, src => src.CreditLimit)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate)
            .Map(dest => dest.InterestRate, src => src.InterestRate)
            .Map(dest => dest.AvailableCredit, src => random.Next(100, 10000))
            .Map(dest => dest.Status, src => "active")
            .Map(dest => dest.CardNumber, src => GenerateRandomCardNumbers());
    }
}
