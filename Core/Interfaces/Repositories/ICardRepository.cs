using Core.DTOs.Card;
using Core.DTOs.Charge;

namespace Core.Interfaces.Repositories;

public interface ICardRepository
{
    Task<CardDTO> Add(CreateCardDTO createCardDTO);
    Task<List<CardDTO>> GetCarsByCustomerId(int id);
    Task<CardDTO> GetCardsById(int id);
}