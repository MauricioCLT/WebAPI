using Core.DTOs.Entity;
using Core.DTOs.Product;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestructura.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private readonly AplicationDbContext _context;

        public EntityRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseEntityDTO> CreateEntity(int id, CreateEntityDTO createEntityDTO)
        {
            var entity = createEntityDTO.Adapt<Entity>();
            var product = createEntityDTO.Product.Adapt<Product>();

            _context.Entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ResponseEntityDTO> GetEntities(int customerId)
        {
            var entityData = await _context.CustomerEntityProducts
                .Include(x => x.EntityCustomer)
                    .ThenInclude(x => x.Customer)
                .Include(x => x.EntityCustomer)
                    .ThenInclude(x => x.Entity)
                .Include(x => x.Product)
                    .ThenInclude(x => x.Entity)
                .Where(x => x.EntityCustomer.CustomerId == customerId)
                .ToListAsync();

            var response = new ResponseEntityDTO
            {
                CustomerName = entityData.FirstOrDefault()?.EntityCustomer.Customer.FirstName ?? "Cliente no encontrado",

                Entities = entityData
                    .GroupBy(e => e.EntityCustomer)
                    .Select(g => new ClientEntityDTO
                    {
                        EntityName = g.First().EntityCustomer.Entity.EntityName,
                        Products = g.Select(p => new ResponseProductDTO
                        {
                            ProductName = p.Product.ProductName,
                            Status = p.Product.Status,
                            ProductDescription = p.Product.ProductDescription,
                            StartDate = p.Product.StartDate,
                        }).ToList()
                    }).ToList()
            };

            return response;
        }
    }
}
