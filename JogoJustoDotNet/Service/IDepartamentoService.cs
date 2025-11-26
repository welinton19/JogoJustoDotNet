using JogoJustoDotNet.Models;
using JogoJustoDotNet.ViewModels;

namespace JogoJustoDotNet.Service;

public interface IDepartamentoService
{
    void CriarDepartamento(string nome);
    void AtualizarDepartamento(int id, string novoNome);
    void DeletarDepartamento(int id);
    IEnumerable <DepartamentoModel> ObterTodosDepartamentos();
    DepartamentoModel ObterDepartamentoPorId(int id);
    void AdicionarDepartamento(DepartamentoViewModel departamento);
}
