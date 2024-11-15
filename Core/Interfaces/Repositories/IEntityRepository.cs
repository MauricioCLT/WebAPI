using Core.DTOs.Entity;
using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface IEntityRepository
{
    Task<ResponseEntityDTO> CreateEntity(CreateEntityDTO createEntityDTO);
    Task<List<ResponseEntityDTO>> GetEntities(int customerId);
}