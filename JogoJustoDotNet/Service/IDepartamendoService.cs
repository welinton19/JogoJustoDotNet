using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.Service;

public interface IDepartamendoService
{
    void CriarDepartamento(string nome);
    void AtualizarDepartamento(int id, string novoNome);
    void DeletarDepartamento(int id);
    IEnumerable <DepartamentoModel> ObterTodosDepartamentos();
    DepartamentoModel ObterDepartamentoPorId(int id);

}
