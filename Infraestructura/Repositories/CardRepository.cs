using Core.DTOs.Card;
using Core.DTOs.Charge;
using Core.DTOs.Payment;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestructura.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories;

public class CardRepository : ICardRepository
{
    private readonly AplicationDbContext _context;

    public CardRepository(AplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CardDTO>> GetCarsByCustomerId(int id)
    {
        var entity = await _context.customers.Include(x => x.Cards).FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
            throw new Exception("No se encontró el Id solicitado");

        return entity.Cards.Adapt<List<CardDTO>>();
    }

    public async Task<DetailedCardDTO> Add(CreateCardDTO createCardDTO)
    {
        var entity = createCardDTO.Adapt<Card>();

        _context.Cards.Add(entity);
        await _context.SaveChangesAsync();

        return entity.Adapt<DetailedCardDTO>();
    }

    public async Task<CardDTO> GetCardsById(int id)
    {
        var entity = await _context.Cards.FirstOrDefaultAsync(x => x.CardId == id);
        if (entity == null)
            throw new Exception("No se encontró el Id solicitado");

        return entity.Adapt<CardDTO>();
    }

    public async Task<ChargeDTO> CreateCharge(CreateChargeDTO createChargeDTO)
    {
        var chargeToCreate = createChargeDTO.Adapt<Charge>();

        var card = await _context.Cards.FindAsync(createChargeDTO.CardId);
        card!.AvailableCredit -= createChargeDTO.Amount;

        _context.Charges.Add(chargeToCreate);
        await _context.SaveChangesAsync();

        return chargeToCreate.Adapt<ChargeDTO>();
    }

    public async Task<PaymentDTO> CreatePayment(CreatePaymentDTO createPaymentDTO)
    {
        var paymentToCreate = createPaymentDTO.Adapt<Payment>();

        var card = await _context.Cards.FindAsync(createPaymentDTO.CardId);
        card!.AvailableCredit += createPaymentDTO.Amount;

        _context.Payments.Add(paymentToCreate);
        await _context.SaveChangesAsync();

        return paymentToCreate.Adapt<PaymentDTO>();
    }

    public async Task<bool> VerifyChargeAmount(int cardId, decimal amount)
    {
        var card = await _context.Cards.FindAsync(cardId);

        if (card == null)
            throw new Exception("No se encontro la tarjeta con el id provisto");

        return card.AvailableCredit >= amount;
    }

    public Task<bool> VerifyPaymentAmount(int cardId, decimal amount)
    {
        throw new NotImplementedException();
    }
}
