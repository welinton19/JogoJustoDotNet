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


    void IFuncionarioService.AtualizarFuncionario(int id, string nome, string cargo, decimal salario) => _funcionarioRepository.AtualizarFuncionario(id, nome, cargo, salario);


    FuncionarioModel IFuncionarioService.ObterFuncionario(int id) => _funcionarioRepository.ObterFuncionario(id);


    void IFuncionarioService.CriarFuncionario(string nome, string cargo, decimal salario) => _funcionarioRepository.CriarFuncionario(nome, cargo, salario);


    


    IEnumerable<FuncionarioModel> IFuncionarioService.ListarFuncionarios() => _funcionarioRepository.ListarFuncionarios();

    

    void IFuncionarioService.DeletarFuncionario(int id)=> _funcionarioRepository.DeletarFuncionario(id);


}
