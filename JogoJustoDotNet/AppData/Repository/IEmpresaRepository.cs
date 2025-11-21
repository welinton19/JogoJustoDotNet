using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.AppData.Repository;

public interface IEmpresaRepository
{
    void CriarEmpresa(string inscricaoestadual, string nome, string endereco, string telefone);
    void AtualizarEmpresa(int id, string inscricaoestadual, string nome, string endereco, string telefone);
    IEnumerable<EmpresaModel> ListarEmpresas();
   
    void DeletarEmpresa(int id);
}
