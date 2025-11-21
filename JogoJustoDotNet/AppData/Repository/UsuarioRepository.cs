using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.AppData.Repository;

public class UsuarioRepository : IUsuarioRepository
{
   private readonly JogoDbContext _jogoDbContext;

    public UsuarioRepository(JogoDbContext jogoDbContext)
    {
        _jogoDbContext = jogoDbContext;
    }

    public void CriarUsuario(string email, string password, string tipo)
    {
       _jogoDbContext.Usuario.Add(new UsuarioModel
       {
           Email = email,
           Password = password,
           Tipo = tipo
       });
        _jogoDbContext.SaveChanges();
    }

    public bool ValidarLogin(string email, string password)
    {
        _jogoDbContext.ChangeTracker.Clear();
        var usuario = _jogoDbContext.Usuario.FirstOrDefault(u => u.Email == email && u.Password == password);
        if(usuario != null)
        {
            return true;
        }
        return false;
    }
}
