using Core.DTOs.Charge;
using Core.Interfaces.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class ChargeController : BaseApiController
{
    private readonly IChargeRepository _chargeRepository;
    private readonly IValidator<CreateChargeDTO> _createChargeValidator;

    public ChargeController(IChargeRepository chargeRepository, IValidator<CreateChargeDTO> createChargeValidator)
    {
        _chargeRepository = chargeRepository;
        _createChargeValidator = createChargeValidator;
    }

    [HttpPost("/Card/{id}/Charges")]
    public async Task<IActionResult> PostCharges([FromRoute] int id, [FromBody] CreateChargeDTO createChargeDTO)
    {
        var result = await _createChargeValidator.ValidateAsync(createChargeDTO);
        if (!result.IsValid)
            return BadRequest(result.Errors);

        return Ok(await _chargeRepository.CreateCharge(id, createChargeDTO));
    }
}
