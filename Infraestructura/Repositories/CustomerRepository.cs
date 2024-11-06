using Core.Entities;
using Core.Interfaces.Repositories;

namespace Infraestructura.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private static List<Customer> _customerList = [
        new () { Id = 1, Name = "Jose" },
        new () { Id = 2, Name = "Juan" }
    ];

    public List<Customer> List()
    {
        return _customerList;
    }

    public void DeleteUser(int id, Customer customer)
    {
        var result = _customerList.FirstOrDefault(x => x.Id == id);
        if (result == null)
            throw new Exception("No se ha encontrado al usuario");

        _customerList.Remove(result);
    }

    public Customer GetById(int id)
    {
        var customerById = _customerList.FirstOrDefault(x => x.Id == id);
        if (customerById == null)
            throw new Exception("No se ha encontrado al usuario");

        return customerById;
    }

    public Customer InsertUser(Customer customer)
    {
        _customerList.Add(customer);

        return customer;
    }

    public Customer UpdateUser(int id, Customer updateCustomer)
    {
        var updateUser = _customerList.FirstOrDefault(x => x.Id == id);
        if (updateUser == null)
            throw new Exception("No se ha encontrado al usuario");

        updateUser.Id = updateCustomer.Id;
        updateUser.Name = updateCustomer.Name;

        return updateUser;
    }

    // Tarea - Agregar - Actualizar, Eliminar, Buscar por Id
}
