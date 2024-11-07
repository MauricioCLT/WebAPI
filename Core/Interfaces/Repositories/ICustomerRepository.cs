using Core.DTOs;
using Core.Request;

namespace Core.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<List<CustomerDTO>> List(PaginationRequest request);
    Task<CustomerDTO> Get(int id);
    Task<CustomerDTO> Add(string firstName, string lastName);
    Task<CustomerDTO> Update(int id, string fistName, string lastName);
    Task<CustomerDTO> Delete(int id);
}