namespace Core.Entities;

public class EntityCustomer
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int EntityId { get; set; }

    // Relations to Entity and Customer Entities
    public Customer Customer { get; set; } = null!;
    public Entity Entity { get; set; } = null!;
    public List<CustomerEntityProduct> CustomersEntitiesProducts { get; set; } = null!;
}
