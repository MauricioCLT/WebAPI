using Core.DTOs.Charge;

namespace Core.Interfaces.Repositories;

public interface IChargeRepository
{
    //Task<ChargeDTO> CreateCharge(int id, CreateChargeDTO createChargeDTO);
    Task<ChargeDTO> CreateCharge(int id, CreateChargeDTO createChargeDTO);

    /// <summary>
    /// Verifica si el monto de la transaccion es permitido. Retorna true si es permitido.
    /// </summary>
    /// <param name="cardId"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    Task<bool> VerifyChargeAmount(int cardId, decimal amount);
}
