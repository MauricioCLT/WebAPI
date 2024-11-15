using Core.DTOs.Product;

namespace Core.Interfaces.Repositories;

public interface IProductRepository
{
    Task<ResponseProductDTO> CreateProduct(CreateProductDTO product);
    Task<ResponseProductDTO> ResponseProductDTO(int customerId);
}
