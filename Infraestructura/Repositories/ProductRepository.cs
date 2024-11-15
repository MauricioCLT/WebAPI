using Core.DTOs.Product;
using Core.Interfaces.Repositories;

namespace Infraestructura.Repositories;

public class ProductRepository : IProductRepository
{
    public Task<ResponseProductDTO> CreateProduct(CreateProductDTO product)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseProductDTO> ResponseProductDTO(int customerId)
    {
        throw new NotImplementedException();
    }
}
