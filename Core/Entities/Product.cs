namespace Core.Entities;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }

    // Relations
    public int EntityId { get; set; }
    public Entity Entity { get; set; } = null!;
    public List<CustomerEntityProduct> CustomersEntitiesProducts { get; set; } = null!;
}
