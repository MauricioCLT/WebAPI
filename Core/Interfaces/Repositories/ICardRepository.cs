using Core.DTOs.Card;

namespace Core.Interfaces.Repositories;

public interface ICardRepository
{
    Task<CardDTO> Add(CreateCardDTO createCardDTO);
    Task<List<CardDTO>> GetCarsByCustomerId(int id);
    Task<CardDTO> GetCardsById(int id);
}