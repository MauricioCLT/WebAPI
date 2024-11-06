using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class CustomerController : BaseApiController
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet("list")]
    public IActionResult List()
    {
        return Ok(_customerRepository.List());
    }

    // Buscar por Id del usuario.
    [HttpGet("getById/{id}")]
    public IActionResult ListUser([FromRoute] int id)
    {
        var getById = _customerRepository.GetById(id);

        return Ok(getById);
    }

    // Agregar usuarios
    [HttpPost("insert")]
    public IActionResult InsertUsers([FromBody] Customer newcustomer)
    {
        var insert = _customerRepository.InsertUser(newcustomer);

        return Ok(insert);
    }

    // Actualizar
    [HttpPut("update/{id}")]
    public IActionResult updateUser([FromRoute] int id, [FromBody] Customer updateCustomer)
    {
        var update = _customerRepository.UpdateUser(id, updateCustomer);

        return Ok(update);
    }

    // Eliminar
    [HttpDelete("delete/{id}")]
    public IActionResult deleteUser([FromRoute] int id, Customer deleteCustomer)
    {
        _customerRepository.DeleteUser(id, deleteCustomer);

        return Ok();
    }
}
