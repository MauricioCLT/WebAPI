using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface ICustomerEntityProductRepository
{
    Task<List<CustomerEntityProduct>> GetCustomerEntityProducts(int id);
}