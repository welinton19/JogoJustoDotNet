namespace JogoJustoDotNet.Service;

public interface ITokenService
{
    string GetRoleFromToken(string token);
    Task<bool> IsTokenValidAsync(string token);
}
