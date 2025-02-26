namespace MinimalAPI.BasicAuthServices;

public interface IBasicAuthService
{
    Task<string> GetUserName();
}