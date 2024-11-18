
using Core.DTOs.Entity;
using Core.DTOs.Product;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Mapster;

namespace Infraestructura.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IEntityRepository _entityRepository;
    private readonly ICustomerEntityProductRepository _customerEntityProductRepository;

    public CustomerService(
        ICustomerRepository customerRepository, 
        IEntityRepository entityRepository,
        ICustomerEntityProductRepository customerEntityProductRepository
        )
    {
        _customerRepository = customerRepository;
        _entityRepository = entityRepository;
        _customerEntityProductRepository = customerEntityProductRepository;
    }

    // Create Entity and Product for a specific customer
    public async Task<ResponseEntityDTO> CreateEntity(int id, CreateEntityDTO createEntityDTO)
    {
        return await _entityRepository.CreateEntity(id, createEntityDTO);
    }

    public async Task<ResponseEntityDTO> GetEntities(int id)
    {
        return await _entityRepository.GetEntities(id);
    }
}
