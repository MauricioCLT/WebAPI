namespace Core.Entities;

public class CustomerEntityProduct
{
    public int EntityCustomerId { get; set; }
    public int ProductId { get; set; }
    public EntityCustomer EntityCustomer { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
