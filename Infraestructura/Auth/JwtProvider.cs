using Core.Interfaces.Services.Auth;
using Core.Jwt;
using Infraestructura.AuthBearerConfiguration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infraestructura.Auth;

public class JwtProvider : IJwtProvider
{
    //private readonly JwtProperties _jwt;

    //public JwtProvider(IOptions<JwtProperties> jwt)
    //{
    //    _jwt = jwt.Value;
    //    _jwt.JwtSecretKey = jwt.Value.JwtSecretKey;
    //    // jwt.Value.Issuer = "CLTAPI";
    //    // jwt.Value.Audience = "https://localhost:5139/";
    //    // jwt.Value.ExpirationTime = 60;
    //}

    public string GenerateToken(IEnumerable<string> Roles)
    {
        // Los roles que pueden tener son de Admin y Seguridad
        // var userRoles = new List<string> { "Admin" /*, "Seguridad"*/ };
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, "1"),
            new Claim(JwtRegisteredClaimNames.Name, "Mauricio")
        };

        foreach (var role in Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtProperties.JwtSecretKey));
        var signInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
                JwtProperties.Issuer,
                JwtProperties.Audience,
                claims,
                null,
                DateTime.UtcNow.AddMinutes(JwtProperties.ExpirationTime),
                signInCredentials
        );

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }
}
