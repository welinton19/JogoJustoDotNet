using JogoJustoDotNet.AppData.Repository;

namespace JogoJustoDotNet.Service
{
    public class UsuarioService : IUsuarioRepository
    {
        
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        void IUsuarioRepository.CriarUsuario(string email, string password, string tipo) => _usuarioRepository.CriarUsuario(email, password, tipo);


        bool IUsuarioRepository.ValidarLogin(string email, string password)
        {
            var validarLogin = _usuarioRepository.ValidarLogin(email, password);
            return validarLogin;
        }
    }
}
