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

        void IUsuarioService.CriarUsuario(string email, string password, string tipo) => _usuarioRepository.CriarUsuario(email, password, tipo);


        bool IUsuarioService.ValidarLogin(string email, string password)
        {
            var validarLogin = _usuarioRepository.ValidarLogin(email, password);
            return validarLogin;
        }
    }
}
