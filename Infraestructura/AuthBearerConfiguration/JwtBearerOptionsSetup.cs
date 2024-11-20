using Core.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace Infraestructura.AuthBearerConfiguration;

public class JwtBearerOptionsSetup : IConfigureOptions<JwtBearerOptions>
{
    public void Configure(JwtBearerOptions options)
    {
        var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtProperties.JwtSecretKey));

        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = JwtProperties.Issuer,
            IssuerSigningKey = issuerSigningKey
        };
    }
}