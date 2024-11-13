using Core.DTOs.Payment;
using Core.Interfaces.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class PaymentController : BaseApiController
{ 
    private readonly IPaymentRepository _paymentRepository;
    private readonly IValidator<CreatePaymentDTO> _createPaymentValidator;

    public PaymentController(IPaymentRepository paymentRepository, IValidator<CreatePaymentDTO> createPaymentValidator)
    {
        _paymentRepository = paymentRepository;
        _createPaymentValidator = createPaymentValidator;
    }

    [HttpPost("Cards/{id}/payments")]
    public async Task<IActionResult> PostPayments([FromRoute] int id, [FromBody] CreatePaymentDTO createPaymentDTO)
    {
        var result = await _createPaymentValidator.ValidateAsync(createPaymentDTO);
        if (!result.IsValid)
            return BadRequest(result.Errors);

        return Ok(await _paymentRepository.AddPaymentById(id, createPaymentDTO));
    }
}
