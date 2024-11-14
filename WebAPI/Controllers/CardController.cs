using Core.DTOs.Card;
using Core.DTOs.Charge;
using Core.Interfaces.Repositories;
using FluentValidation;
using Infraestructura.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class CardController : BaseApiController
{
    private readonly ICardRepository _cardRepository;
    private readonly ITransactionsRepository _transactionsRepository;
    private readonly IValidator<CreateCardDTO> _validator;

    public CardController(ICardRepository cardRepository, ITransactionsRepository transactionsRepository, IValidator<CreateCardDTO> validateCreateCardDTO)
    {
        _cardRepository = cardRepository;
        _transactionsRepository = transactionsRepository;
        _validator = validateCreateCardDTO;
    }

    [HttpPost("/Cards")]
    public async Task<IActionResult> PostCard([FromBody] CreateCardDTO createCardDTO)
    {
        var result = await _validator.ValidateAsync(createCardDTO);
        if (!result.IsValid)
            return BadRequest(result.Errors);

        return Ok(await _cardRepository.Add(createCardDTO));
    }

    [HttpGet("/Cars/{id}")]
    public async Task<IActionResult> GetCarsById([FromRoute] int id)
    {
        return Ok(await _cardRepository.GetCardsById(id));
    }

    [HttpGet("/Customers/{id}/Cards")]
    public async Task<IActionResult> GetCarsByCustomerId([FromRoute] int id)
    {
        return Ok(await _cardRepository.GetCarsByCustomerId(id));
    }

    [HttpPost("/Charges")]
    public async Task<IActionResult> CreateCharge([FromBody] CreateChargeDTO createChargeDTO)
    {
        //var result = await _validator.ValidateAsync(createChargeDTO);
        //if (!result.IsValid)
          //  return BadRequest(result.Errors);

        return Ok(await _cardRepository.CreateCharge(createChargeDTO));
    }

    [HttpGet("Cards/{cardId}/transactions")]
    public async Task<IActionResult> GetAllTransactionCharges([FromRoute] int cardId, [FromQuery] DateOnly startDate, [FromQuery] DateOnly endDate)
    {
        return Ok(await _transactionsRepository.GetTransactions(cardId, startDate, endDate));
    }
}
