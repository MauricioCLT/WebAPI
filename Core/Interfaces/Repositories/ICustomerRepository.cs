using Core.DTOs;

namespace Core.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<List<CustomerDTO>> List();
    Task<CustomerDTO> Get(int id);
    Task<List<CustomerDTO>> Add(string firstName, string lastName);
    Task<CustomerDTO> Update(int id, string fistName, string lastName);
    Task<CustomerDTO> Delete(int id);
}