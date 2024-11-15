namespace Core.Entities;

public class Entity
{
    public int Id { get; set; }
    public string EntityName { get; set; } = string.Empty;

    public List<EntityCustomer> EntityCustomers { get; set; } = null!;
    public List<Product> Products { get; set; } = null!;
}
