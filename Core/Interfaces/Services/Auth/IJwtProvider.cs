namespace Core.Interfaces.Services.Auth;

public interface IJwtProvider
{
    string GenerateToken(IEnumerable<string> Roles);
}
