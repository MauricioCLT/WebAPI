using Core.DTOs.Entity;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestructura.Contexts;
using Mapster;

namespace Infraestructura.Repositories;

public class EntityRepository : IEntityRepository
{
    private readonly AplicationDbContext _context;

    public EntityRepository(AplicationDbContext context)
    {
        _context = context;
    }
}
