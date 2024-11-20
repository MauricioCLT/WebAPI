using Core.Interfaces.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class AuthController : BaseApiController
{
    private readonly IJwtProvider _jwtProvider;

    public AuthController(IJwtProvider jwtProvider)
    {
        _jwtProvider = jwtProvider;
    }

    // Generate a secret jwt
    [HttpGet("Generate-Token")]
    [AllowAnonymous]
    public IActionResult GenerateToken([FromQuery] IEnumerable<string> roles, [FromQuery] string name)
    {
        string token = _jwtProvider.GenerateToken(roles, name);

        return Ok(token);
    }

    // Get a Ok if the secret token is correct 
    [HttpGet("Protected-Endpoint")]
    [Authorize]
    public IActionResult ProtectedEndpoint()
    {
        return Ok("Esto es un endpoint protegido");
    }

    // Get a Ok if the user has a seguridad Rol only if Seguridad
    [HttpGet("Protected-Endpoint-Seguridad")]
    [Authorize(Roles = "Seguridad")]
    public IActionResult ProtectedSecurityRol()
    {
        return Ok("Acceso solo a miembros con rol de seguridad");
    }

    // Get a Ok if the user has a Admin Rol only if admin
    [HttpGet("Protected-Endpoint-Admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult ProtectedAdminRol()
    {
        return Ok("Acceso solo a miembros con rol de Admin");
    }

    // Get a Ok if the user has a seguridad o Admin Roles o seguridad o Admin
    [HttpGet("Protected-Endpoint-Ambos")]
    [Authorize(Roles = "Admin,Seguridad")]
    public IActionResult ProtectedBothRol()
    {
        return Ok("Acceso a miebros con roles de Seguridad y Admin");
    }
}
