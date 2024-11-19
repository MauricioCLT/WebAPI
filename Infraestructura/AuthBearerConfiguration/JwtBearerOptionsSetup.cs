using Core.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace Infraestructura.AuthBearerConfiguration;

public class JwtBearerOptionsSetup : IConfigureOptions<JwtBearerOptions>
{
    private readonly JwtProperties _jwtProperties;
    
    public JwtBearerOptionsSetup(IOptions<JwtProperties> jwtProperties)
    {
        _jwtProperties = jwtProperties.Value;
    }

    public void Configure(JwtBearerOptions options)
    {
        var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtProperties.JwtSecretKey));

        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _jwtProperties.Issuer,
            IssuerSigningKey = issuerSigningKey
        };
    }
}