using Core.DTOs.Entity;
using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface IEntityRepository
{
    Task<ResponseEntityDTO> CreateEntity(int id, CreateEntityDTO createEntityDTO);
    Task<ResponseEntityDTO> GetEntities(int customerId);
}