using Core.DTOs.Entity;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestructura.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories;

public class EntityRepository : IEntityRepository
{
    private readonly AplicationDbContext _context;

    public EntityRepository(AplicationDbContext context)
    {
        _context = context;
    }

    public Task<ResponseEntityDTO> CreateEntity(CreateEntityDTO createEntityDTO)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ResponseEntityDTO>> GetEntities(int id)
    {
        var entityWithProducts = await _context.EntitiesCustomers
            .Where(x => x.CustomerId == id)
            .Include(x => x.)
            .ToListAsync();

        
    }
}
