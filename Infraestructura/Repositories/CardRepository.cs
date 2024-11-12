using Core.DTOs.Card;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Request;
using Infraestructura.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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

    public async Task<CardDTO> Add(CreateCardDTO createCardDTO)
    {
        var entity = createCardDTO.Adapt<Card>();

        _context.Cards.Add(entity);
        await _context.SaveChangesAsync();

        return entity.Adapt<CardDTO>();
    }

    public async Task<CardDTO> GetCardsById(int id)
    {
        var entity = await _context.Cards.FirstOrDefaultAsync(x => x.CardId == id);
        if (entity == null)
            throw new Exception("No se encontró el Id solicitado");

        return entity.Adapt<CardDTO>();
    }
}
