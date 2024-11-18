using Core.Entities;
using Infraestructura.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Contexts;

public partial class AplicationDbContext : DbContext
{
    public DbSet<Customer> customers { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Charge> Charges { get; set; }
    public DbSet<Entity> Entities { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<EntityCustomer> EntitiesCustomers { get; set; }
    public DbSet<CustomerEntityProduct> CustomerEntityProducts { get; set; }

    public AplicationDbContext()
    {}

    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new CardConfiguration());
        modelBuilder.ApplyConfiguration(new ChargeConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new EntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new EntityCustomerConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerEntityProductConfiguration());
    }

    partial void OnModelCratingPartial(ModelBuilder modelBuilder);
}
