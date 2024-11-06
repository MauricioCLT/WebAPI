using Core.Entities;
using Infraestructura.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Contexts;

public partial class AplicationDbContext : DbContext
{
    public DbSet<Customer> customers { get; set; }

    public AplicationDbContext()
    {}

    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());   
    }

    partial void OnModelCratingPartial(ModelBuilder modelBuilder);
}
