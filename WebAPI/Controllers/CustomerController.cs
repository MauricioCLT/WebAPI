using Core.DTOs.Customer;
using Core.DTOs.Entity;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Request;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebApi.Controllers;

public class CustomerController : BaseApiController
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IEntityRepository _entityRepository;
    private readonly IValidator<CreateCustomerDTO> _validateCreateCustomerDTO;
    private readonly IValidator<UpdateCustomerDTO> _updateCustomerDTO;
    private readonly ICustomerEntityProductRepository _customerEntityProductRepository;
    private readonly ICustomerService _customerService;

    public CustomerController(
            ICustomerRepository customerRepository,
            IValidator<CreateCustomerDTO> validateCreateCustomerDTO,
            IValidator<UpdateCustomerDTO> updateCustomerDTO,
            IEntityRepository entityRepository,
            ICustomerEntityProductRepository customerEntityProductRepository,
            ICustomerService customerService
        )
    {
        _customerRepository = customerRepository;
        _validateCreateCustomerDTO = validateCreateCustomerDTO;
        _updateCustomerDTO = updateCustomerDTO;
        _entityRepository = entityRepository;
        _customerEntityProductRepository = customerEntityProductRepository;
        _customerService = customerService;
    }

    [HttpGet("list")]
    public async Task<IActionResult> List([FromQuery] PaginationRequest request, CancellationToken cancellationToken)
    {
        return Ok(await _customerRepository.List(request, cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        return Ok(await _customerRepository.Get(id));
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateCustomerDTO createCustomerDTO)
    {
        var result = await _validateCreateCustomerDTO.ValidateAsync(createCustomerDTO);
        if (!result.IsValid)
            return BadRequest(result.Errors);

        return Ok(await _customerRepository.Add(createCustomerDTO));
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerDTO updateCustomerDTO)
    {
        var result = await _updateCustomerDTO.ValidateAsync(updateCustomerDTO);
        if (!result.IsValid)
            return BadRequest(result.Errors);

        return Ok(await _customerRepository.Update(updateCustomerDTO));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _customerRepository.Delete(id));
    }

    // GET para las entidades y productos de un customer
    [HttpGet("{id}/entities")]
    public async Task<IActionResult> GetCustomerEntitiesProducts([FromRoute] int id)
    {
        var result = await _customerService.GetEntities(id);

        if (result == null)
            return BadRequest("No entities found");

        return Ok(result);
    }

    [HttpPost("{id}/entities")]
    public async Task<IActionResult> CreateEntityProduct([FromRoute] int id, [FromBody] CreateEntityDTO createEnityDTO)
    {
        return Ok(await _entityRepository.CreateEntity(id, createEnityDTO));
    }
}