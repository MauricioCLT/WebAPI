using Core.Entities;
using Core.DTOs;
using Core.Interfaces.Repositories;
using Infraestructura.Contexts;
using Microsoft.EntityFrameworkCore;
using Core.Request;

namespace Infraestructura.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AplicationDbContext _context;

    public CustomerRepository(AplicationDbContext context)
    {
        _context = context;        
    }

    public async Task<CustomerDTO> Add(string firstName, string lastName)
    {
        var entity = new Customer
        {
            FirstName = firstName,
            LastName = lastName,
        };

        _context.customers.Add(entity);
        await _context.SaveChangesAsync();

        var dtos = new CustomerDTO
        {
            Id = entity.Id,
            FullName = $"{entity.FirstName} {entity.LastName}"
        };

        return dtos;
    }

    public async Task<CustomerDTO> Delete(int id)
    {
        var entity = await _context.customers.FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
            throw new Exception("No se encontro el Id");

        var dtos = new CustomerDTO
        {
            Id = id,
            FullName = $"{entity.FirstName} {entity.LastName}"
        };

        _context.customers.Remove(entity);
        await _context.SaveChangesAsync();

        return dtos;
    }

    public async Task<CustomerDTO> Get(int id)
    {
        var entity = await _context.customers.FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
            throw new Exception("No se encontro el Id");

        var dtos = new CustomerDTO
        {
            Id = id,
            FullName = $"{entity.FirstName} {entity.LastName}"
        };

        return dtos;
    }

    public async Task<List<CustomerDTO>> List(PaginationRequest request)
    {
        var entities = await _context.customers.ToListAsync();

        var dtos = entities
            .Skip((request.Page -1) * request.PageSize)
            .Take(request.PageSize)
            .Select(customer => new CustomerDTO
        {
            Id = customer.Id,
            FullName = $"{customer.FirstName} {customer.LastName}",
            Phone = customer.Phone,
            Email = customer.Email,
            BirthDate = customer.BirthDate.ToShortDateString(),
        });

        return dtos.ToList();
    }

    public async Task<CustomerDTO> Update(int id, string firstName, string lastName)
    {
        var updateUser = await _context.customers.FirstOrDefaultAsync(customer => customer.Id == id);

        if (updateUser == null)
            throw new Exception("No se ha encontrado el Id");

        // updateUser.Id = id;
        updateUser.FirstName = firstName;
        updateUser.LastName = lastName;

        var dtos = new CustomerDTO
        {
            Id= id,
            FullName = $"{updateUser.FirstName} {updateUser.LastName}"
        };

        await _context.SaveChangesAsync();

        return dtos;
    }
}