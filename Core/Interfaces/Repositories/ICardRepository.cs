using Core.DTOs.Card;
using Core.DTOs.Charge;

namespace Core.Interfaces.Repositories;

public interface ICardRepository
{
    Task<DetailedCardDTO> Add(CreateCardDTO createCardDTO);
    Task<List<CardDTO>> GetCarsByCustomerId(int id);
    Task<CardDTO> GetCardsById(int id);
    Task<ChargeDTO> CreateCharge(CreateChargeDTO request);
    Task<bool> VerifyChargeAmount(int cardId, decimal amount);
}