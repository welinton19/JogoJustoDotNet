using JogoJustoDotNet.AppData.Repository;
using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.Service;

public class FuncionarioService : IFuncionarioService
{
    private readonly IFuncionarioRepository _funcionarioRepository;

    public FuncionarioService(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
    }

    public void DeletarFuncionario(int id) => _funcionarioRepository.DeletarFuncionario(id);


    public void AtualizarFuncionario(int id, string nome, string cargo, decimal salario) => _funcionarioRepository.AtualizarFuncionario(id, nome, cargo, salario);


    public FuncionarioModel ObterFuncionario(int id) => _funcionarioRepository.ObterFuncionario(id);


    public void CriarFuncionario(string nome, string cargo, decimal salario) => _funcionarioRepository.CriarFuncionario(nome, cargo, salario);

    
    public IEnumerable<FuncionarioModel> ListarFuncionarios() => _funcionarioRepository.ListarFuncionarios();

}
