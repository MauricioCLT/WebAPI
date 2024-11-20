using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infraestructura.AuthBearerConfiguration;

public class JwtOptions : IConfigureOptions<JwtOptions>
{
    private readonly IConfiguration _configuration;

    public JwtOptions(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // 
    public void Configure(JwtOptions jwtOptions)
    {
        _configuration.GetSection("Jwt").Get<JwtOptions>();
    }
}
