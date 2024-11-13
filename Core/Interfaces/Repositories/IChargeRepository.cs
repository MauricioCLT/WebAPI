using Core.DTOs.Charge;

namespace Core.Interfaces.Repositories;

public interface IChargeRepository
{
    Task<ChargeDTO> AddChargeById(int id, CreateChargeDTO createChargeDTO);
}
