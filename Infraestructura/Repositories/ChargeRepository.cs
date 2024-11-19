using Core.DTOs.Charge;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestructura.Contexts;
using Mapster;

namespace Infraestructura.Repositories;

public class ChargeRepository : IChargeRepository
{
    private readonly AplicationDbContext _context;

    public ChargeRepository(AplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ChargeDTO> CreateCharge(int id, CreateChargeDTO createChargeDTO)
    {
        var chargeToCreate = createChargeDTO.Adapt<Charge>();

        var card = await _context.Cards.FindAsync(id);
        card!.AvailableCredit = chargeToCreate.AvailableCredit - createChargeDTO.Amount;

        _context.Charges.Add(chargeToCreate);
        await _context.SaveChangesAsync();

        return card.Adapt<ChargeDTO>();
    }

    public async Task<bool> VerifyChargeAmount(int cardId, decimal amount)
    {
        var card = await _context.Cards.FindAsync(cardId);

        if (card == null)
            throw new Exception("No se encontro la tarjeta con el id provisto");

        return card.AvailableCredit >= amount;
    }
}