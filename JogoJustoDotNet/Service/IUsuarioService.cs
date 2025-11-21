namespace JogoJustoDotNet.Service;

public interface IUsuarioService
{
    void CriarUsuario(string email, string password, string tipo);
    bool ValidarLogin(string email, string password);
    
}
