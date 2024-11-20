namespace Core.Jwt;

public class JwtProperties
{
    public static string JwtSecretKey { get; set; } = string.Empty;
    public static string Audience { get; set; } = string.Empty;
    public static string Issuer { get; set; } = string.Empty;
    public static int ExpirationTime { get; set; }
}
