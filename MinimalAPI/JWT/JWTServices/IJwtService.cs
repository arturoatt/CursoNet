namespace MinimalAPI.JWT.JwtServices;

public interface IJwtService
{
    string GeneraToken(string username);
}