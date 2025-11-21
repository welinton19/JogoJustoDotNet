namespace JogoJustoDotNet.Auth;

public class JwtSettings
{
    public string Secret { get; set; } = string.Empty;
    public int ExpirationInHours { get; set; } = 1;
}
