using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Request;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebApi.Controllers;

public class CustomerController : BaseApiController
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IValidator<CreateCustomerDTO> _validateCreateCustomerDTO;
    private readonly IValidator<UpdateCustomerDTO> _updateCustomerDTO;

    public CustomerController(ICustomerRepository customerRepository, IValidator<CreateCustomerDTO> validateCreateCustomerDTO, IValidator<UpdateCustomerDTO> updateCustomerDTO)
    {
        _customerRepository = customerRepository;
        _validateCreateCustomerDTO = validateCreateCustomerDTO;
        _updateCustomerDTO = updateCustomerDTO;
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
}