using JogoJustoDotNet.AppData.Repository;

namespace JogoJustoDotNet.Service
{
    public class UsuarioService : IUsuarioService
    {
        
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void CriarUsuario(string email, string password, string tipo) => _usuarioRepository.CriarUsuario(email, password, tipo);


        public bool ValidarLogin(string email, string password)
        {
            var validarLogin = _usuarioRepository.ValidarLogin(email, password);
            return validarLogin;
        }
    }
}
