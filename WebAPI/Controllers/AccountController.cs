using Core.Interfaces.Repositories;
using Infraestructura.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class AccountController : BaseApiController
{
    private readonly IAccountRepository _accountRepository;

    public AccountController(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    [HttpGet("/Account/{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        return Ok(await _accountRepository.GetById(id));
    }
}
