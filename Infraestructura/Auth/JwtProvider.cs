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
    public string GenerateToken(IEnumerable<string> Roles, string name)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, "1"),
            new Claim(JwtRegisteredClaimNames.Name, name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
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
