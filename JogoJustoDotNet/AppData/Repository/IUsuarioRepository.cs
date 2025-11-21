namespace JogoJustoDotNet.AppData.Repository;

public interface IUsuarioRepository
{
    void CriarUsuario(string email, string password, string tipo);
    bool ValidarLogin(string email, string password);
}
