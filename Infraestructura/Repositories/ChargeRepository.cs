using Core.DTOs.Card;
using Core.DTOs.Charge;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestructura.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories;

public class ChargeRepository : IChargeRepository
{
    private readonly AplicationDbContext _context;

    public ChargeRepository(AplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ChargeDTO> AddChargeById(int id, CreateChargeDTO createChargeDTO)
    {
        // Buscar la tarjeta por su ID
        var card = await _context.Cards.FirstOrDefaultAsync(x => x.CardId == id);
        if (card == null)
            throw new Exception("No se encontró el Id de la tarjeta");

        var NewAvailableCredit = card.AvailableCredit >= createChargeDTO.Amount
            ? card.AvailableCredit - createChargeDTO.Amount
            : throw new Exception("La carga que se desea realizar es mayor al credito disponible");

        var charge = new Charge
        {
            CardId = id,
            Amount = createChargeDTO.Amount,
            Description = createChargeDTO.Description,
            AvailableCredit = NewAvailableCredit,
            Date = createChargeDTO.Date
        };

        var dtos = new ChargeDTO
        {
            ChargeId = charge.ChargerId,
            CardId = id,
            Amount = charge.Amount,
            Description = charge.Description,
            AvailableCredit = NewAvailableCredit,
            Date = charge.Date
        };

        _context.Charges.Add(charge);
        await _context.SaveChangesAsync();

        return dtos;
    }
}
