using Core.DTOs.Account;

namespace Core.Interfaces.Repositories;

public interface IAccountRepository
{
    Task<DetailedAccountDTO> GetById(int id);
}
