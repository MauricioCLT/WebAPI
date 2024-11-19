namespace Core.Jwt;

public class JwtProperties
{
    public string JwtSecretKey { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public int ExpirationTime { get; set; }
}
