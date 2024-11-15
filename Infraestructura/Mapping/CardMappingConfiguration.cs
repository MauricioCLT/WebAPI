using Core.DTOs.Card;
using Core.DTOs.Charge;
using Core.DTOs.Payment;
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

        for (int i = 0; i < 12; i++)
        {
            number += random.Next(0, 10);
        }

        return number;
    }

    public void Register(TypeAdapterConfig config)
    {
        var random = new Random();

        // Card Mapping Create Post
        config.NewConfig<CreateCardDTO, Card>()
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            .Map(dest => dest.CardType, src => src.CardType)
            .Map(dest => dest.CreditLimit, src => src.CreditLimit)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate)
            .Map(dest => dest.InterestRate, src => src.InterestRate)
            .Map(dest => dest.AvailableCredit, src => random.Next(100, 100000))
            .Map(dest => dest.Status, src => "active")
            .Map(dest => dest.CardNumber, src => GenerateRandomCardNumbers());

        // Card Mapping Create Response
        config.NewConfig<Card, DetailedCardDTO>()
            .Map(dest => dest.CustomerId, src => src.CustomerId)
            .Map(dest => dest.CreditLimit, src => src.CreditLimit)
            .Map(dest => dest.ExpirationDate, src => src.ExpirationDate)
            .Map(dest => dest.InterestRate, src => src.InterestRate)
            .Map(dest => dest.AvailableCredit, src => src.AvailableCredit)
            .Map(dest => dest.CardNumber, src => $"XXXX-XXXX-XXXX-{src.CardNumber.Substring(src.CardNumber.Length - 4, 4)}");

        // Realize a Payment from a specific credit card
        config.NewConfig<ResponsePaymentDTO, Payment>()
            .Map(dest => dest.PaymentId, src => src.PaymentId)
            .Map(dest => dest.CardId, src => src.CardId)
            //.Map(dest => dest.Amount, src => src.Amount)
            //.Map(dest => dest.AvailableCredit, src => src.AvailableCredit)
            .Map(dest => dest.Date, src => src.Date);

        config.NewConfig<Charge, ChargeDTO>()
            .Map(dest => dest.ChargeId, src => src.ChargerId)
            .Map(dest => dest.CardId, src => src.CardId)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.AvailableCredit, src => src.AvailableCredit)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Date, src => src.Date.ToShortDateString());
    }
}
