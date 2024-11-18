using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestructura.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories;

public class CustomerEntityProductRepository : ICustomerEntityProductRepository
{
    private readonly AplicationDbContext _context;

    public CustomerEntityProductRepository(AplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<CustomerEntityProduct>> GetCustomerEntityProducts(int id)
    {
        var entity = await _context.CustomerEntityProducts
            .Include(x => x.EntityCustomer)
            .ThenInclude(x => x.Customer)
            .Include(x => x.EntityCustomer)
            .ThenInclude(x => x.Entity)
            .Include(x => x.Product)
            .ThenInclude(x => x.Entity)
            .Where(x => x.EntityCustomer.CustomerId == id)
            .ToListAsync();
        
        return entity;
    }
}