using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.AppData.Repository;

public interface IFuncionarioRepository
{
    void CriarFuncionario(string nome, string cargo, decimal salario);
    IEnumerable<Models.FuncionarioModel> ListarFuncionarios();
    
    FuncionarioModel ObterFuncionario(int id);
    void AtualizarFuncionario(int id, string nome, string cargo, decimal salario);
    void DeletarFuncionario(int id);
}
