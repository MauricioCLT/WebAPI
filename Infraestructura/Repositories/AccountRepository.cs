using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Request;
using Infraestructura.Contexts;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly AplicationDbContext _context;

    public AccountRepository(AplicationDbContext context)
    {
        _context = context;
    }

    private static DetailedAccountDTO accountDTO(Account account) => new()
    {
        Id = account.Id,
        Number = account.Number,
        Balance = account.Balance,
        OpeningDate = account.OpeningDate.ToShortDateString(),
        Customer = new CustomerDTO
        {
            Id = account.Customer.Id,
            FullName = $"{account.Customer.FirstName} {account.Customer.LastName}",
            Email = account.Customer.Email,
            Phone = account.Customer.Phone,
            BirthDate = account.Customer.BirthDate.ToShortDateString()
        }
    };

    public async Task<DetailedAccountDTO> GetById(int id)
    {
        var entity = await _context.Accounts.Include(x => x.Customer).FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
            throw new Exception("No se encontro el Id");

        return entity.Adapt<DetailedAccountDTO>();
    }
}
