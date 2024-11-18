using Core.DTOs.Charge;
using Core.DTOs.Payment;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Infraestructura.Services;

public class CardService : ICardServices
{
    private readonly ICardRepository _cardRepository;

    public CardService(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public async Task<ChargeDTO> CreateCharge(CreateChargeDTO request)
    {
        var isTransactionAllowed = await _cardRepository
            .VerifyChargeAmount(request.CardId, request.Amount);

        if (!isTransactionAllowed)
            throw new Exception("El monto supera el limite");

        return await _cardRepository.CreateCharge(request);
    }

    public Task<PaymentDTO> CreatePayment(CreatePaymentDTO request)
    {
        throw new NotImplementedException();
    }
}
