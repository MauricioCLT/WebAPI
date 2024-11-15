using Core.DTOs.Product;

namespace Core.DTOs.Entity;

public class ClientEntityDTO
{
    public string EntityName { get; set; } = string.Empty;
    public List<ResponseProductDTO> Products { get; set; } = null!;
}
