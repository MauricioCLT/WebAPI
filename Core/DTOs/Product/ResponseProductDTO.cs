namespace Core.DTOs.Product;

public class ResponseProductDTO
{
    public string ProductName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
}
