using JogoJustoDotNet.Models;
using JogoJustoDotNet.ViewModels;

namespace JogoJustoDotNet.Service;

public interface IEmpresaService
{
    void CriarEmpresa(string inscricaoestadual, string nome, string endereco, string telefone);
    void AtualizarEmpresa(int id, string inscricaoestadual, string nome, string endereco, string telefone);
    IEnumerable<EmpresaModel> ListarEmpresas();
    void DeletarEmpresa(int id);
    void AdicionarEmpresa(EmpresaViewModel empresa);
    void obeterEmpresaPorId(int id);
    void AtualizarEmpresa(int id, EmpresaModel empresaAtualizada);
}
