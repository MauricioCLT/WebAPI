using Core.DTOs.Entity;
using Core.DTOs.Product;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Infraestructura.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<ResponseEntityDTO> CreateEntity(CreateEntityDTO createEntityDTO)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseProductDTO> CreateProduct(CreateProductDTO createProductDTO)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseEntityDTO> GetEntity(int entityId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseProductDTO> GetProduct(int productId)
    {
        throw new NotImplementedException();
    }
}
