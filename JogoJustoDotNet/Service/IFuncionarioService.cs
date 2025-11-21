using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.Service;

public interface IFuncionarioService
{
    void CriarFuncionario(string nome, string cargo, decimal salario);
    IEnumerable<FuncionarioModel> ListarFuncionarios();
    
    FuncionarioModel ObterFuncionario(int id);
    void AtualizarFuncionario(int id, string nome, string cargo, decimal salario);
    void DeletarFuncionario(int id);
}
