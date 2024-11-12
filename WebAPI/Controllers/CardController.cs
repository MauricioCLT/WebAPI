using Core.DTOs.Card;
using Core.Interfaces.Repositories;
using Core.Request;
using FluentValidation;
using Infraestructura.Repositories;
using Infraestructura.Validation.Card;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class CardController : BaseApiController
{
    private readonly ICardRepository _cardRepository;
    private readonly IValidator<CreateCardDTO> _validator;

    public CardController(ICardRepository cardRepository, IValidator<CreateCardDTO> validateCreateCardDTO)
    {
        _cardRepository = cardRepository;
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
        return Ok(await _cardRepository.GetCardsById(id));
    }

    //[HttpGet("list")]
    //public async Task<IActionResult> List([FromQuery] PaginationRequest request, CancellationToken cancellationToken)
    //{
    //    return Ok(await _customerRepository.List(request, cancellationToken));
    //}

}
