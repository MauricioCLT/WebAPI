using Core.DTOs.Product;

namespace Core.DTOs.Entity;

public class ResponseEntityDTO
{
    public string CustomerName { get; set; } = string.Empty;
    public List<ClientEntityDTO> Entities { get; set; } = null!;
}
