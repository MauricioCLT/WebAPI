using Core.Entities;
using Core.DTOs;
using Core.Interfaces.Repositories;
using Infraestructura.Contexts;
using Microsoft.EntityFrameworkCore;
using Core.Request;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace Infraestructura.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AplicationDbContext _context;

    public CustomerRepository(AplicationDbContext context)
    {
        _context = context;
    }

    private CustomerDTO customerDTO(Customer customer) => new()
    {
        Id = customer.Id,
        FullName = $"{customer.FirstName} {customer.LastName}",
        Email = customer.Email,
        Phone = customer.Phone,
        BirthDate = customer.BirthDate.ToShortDateString(),

        Accounts = customer.Accounts.Select(x => new DetailedCustomerDTO
        {
            Id = x.Id,
            Number = x.Number,
            Balance = x.Balance,
            OpeningDate = x.OpeningDate.ToShortDateString()
        }).ToList()
    };

    public async Task<CustomerDTO> Add(CreateCustomerDTO createCustomerDTO)
    {
        var entity = new Customer
        {
            FirstName = createCustomerDTO.FirstName,
            LastName = createCustomerDTO.LastName,
            Email = createCustomerDTO.Email,
            Phone = createCustomerDTO.Phone,
            BirthDate = createCustomerDTO.BirthDate
        };

        _context.customers.Add(entity);
        await _context.SaveChangesAsync();

        return customerDTO(entity);
    }

    public async Task<CustomerDTO> Delete(int id)
    {
        var entity = await _context.customers.FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
            throw new Exception("No se encontro el Id");

        _context.customers.Remove(entity);
        await _context.SaveChangesAsync();

        return customerDTO(entity);
    }

    public async Task<CustomerDTO> Get(int id)
    {
        var entity = await _context.customers.Include(x => x.Accounts).FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
            throw new Exception("No se encontro el Id");


        return customerDTO(entity);
    }

    public async Task<List<CustomerDTO>> List(PaginationRequest request, CancellationToken cancellationToken)
    {
        var dtos = await _context.customers
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(customer => new CustomerDTO
            {
                Id = customer.Id,
                FullName = $"{customer.FirstName} {customer.LastName}",
                Phone = customer.Phone,
                Email = customer.Email,
                BirthDate = customer.BirthDate.ToShortDateString(),
            }).OrderBy(x => x.Id).ToListAsync(cancellationToken);

        return dtos;
    }

    public async Task<CustomerDTO> Update(UpdateCustomerDTO updateCustomerDTO)
    {
        var updateUser = await _context.customers.FirstOrDefaultAsync(customer => customer.Id == updateCustomerDTO.Id);

        if (updateUser == null)
            throw new Exception("No se ha encontrado el Id");

        // updateUser.Id = id;
        updateUser.FirstName = updateCustomerDTO.FirstName;
        updateUser.LastName = updateCustomerDTO.LastName;
        updateUser.Email = updateCustomerDTO.Email;
        updateUser.Phone = updateCustomerDTO.Phone;
        updateUser.BirthDate = updateCustomerDTO.BirthDate;

        var dtos = new CustomerDTO
        {
            Id = updateUser.Id,
            FullName = $"{updateUser.FirstName} {updateUser.LastName}",
            BirthDate = updateUser.BirthDate.ToShortDateString(),
            Phone = updateUser.Phone,
            Email = updateUser.Email,
        };

        await _context.SaveChangesAsync();

        return dtos;
    }
}