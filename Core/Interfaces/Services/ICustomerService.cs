using Core.DTOs.Entity;

namespace Core.Interfaces.Services;

public interface ICustomerService
{
    Task<ResponseEntityDTO> CreateEntity(int id, CreateEntityDTO createEntityDTO);
    Task<ResponseEntityDTO> GetEntities(int customerId);
}
