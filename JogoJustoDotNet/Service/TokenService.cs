using JogoJustoDotNet.AppData;
using Microsoft.EntityFrameworkCore;

namespace JogoJustoDotNet.Service;

public class TokenService : ITokenService
{
    private readonly JogoDbContext _jogoDbContext;

    public TokenService(JogoDbContext jogoDbContext)
    {
        _jogoDbContext = jogoDbContext;
    }

    public async Task<bool> IsTokenValidAsync(string token)
    {
        var tokenRegistro = await  _jogoDbContext.Tokem
            .FirstOrDefaultAsync(t => t.Token == token && t.Ativo);
        return tokenRegistro != null;

    }

    string ITokenService.GetRoleFromToken(string token)
    {
        var tokenRegistro =  _jogoDbContext.Tokem
            .FirstOrDefault(t => t.Token == token && t.Ativo);
        return tokenRegistro?.Role;

    }

    Task<bool> ITokenService.IsTokenValidAsync(string token)
    {
        var tokenRegistro =  _jogoDbContext.Tokem
            .FirstOrDefault(t => t.Token == token && t.Ativo);
        return Task.FromResult(tokenRegistro != null);
    }
}