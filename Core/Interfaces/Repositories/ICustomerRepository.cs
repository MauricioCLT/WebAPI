using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface ICustomerRepository
{
    List<Customer> List();
    public Customer GetById(int id);
    public Customer InsertUser(Customer customer);
    public Customer UpdateUser(int id, Customer customer);
    public void DeleteUser(int id, Customer customer);
}
