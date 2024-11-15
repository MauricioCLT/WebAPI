using Core.DTOs.Entity;
using Core.DTOs.Product;

namespace Core.Interfaces.Services;

public interface ICustomerService
{
    Task<ResponseEntityDTO> CreateEntity(CreateEntityDTO createEntityDTO);
    Task<ResponseEntityDTO> GetEntity(int entityId);
    Task<ResponseProductDTO> CreateProduct(CreateProductDTO createProductDTO);
    Task<ResponseProductDTO> GetProduct(int productId);
}
