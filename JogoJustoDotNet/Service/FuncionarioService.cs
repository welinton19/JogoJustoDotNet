using JogoJustoDotNet.AppData.Repository;
using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.Service;

public class FuncionarioService : IFuncionarioRepository
{
    private readonly IFuncionarioRepository _funcionarioRepository;

    public FuncionarioService(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
    }

    public void DeletarFuncionario(int id) => _funcionarioRepository.DeletarFuncionario(id);


    void IFuncionarioRepository.AtualizarFuncionario(int id, string nome, string cargo, decimal salario) => _funcionarioRepository.AtualizarFuncionario(id, nome, cargo, salario);


    FuncionarioModel IFuncionarioRepository.ObterFuncionario(int id) => _funcionarioRepository.ObterFuncionario(id);


    void IFuncionarioRepository.CriarFuncionario(string nome, string cargo, decimal salario) => _funcionarioRepository.CriarFuncionario(nome, cargo, salario);


    


    IEnumerable<FuncionarioModel> IFuncionarioRepository.ListarFuncionarios() => _funcionarioRepository.ListarFuncionarios();

}
