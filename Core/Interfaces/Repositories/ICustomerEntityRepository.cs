using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface ICustomerEntityRepository
{
    Task<EntityCustomer> Get();
}
