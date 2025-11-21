using JogoJustoDotNet.AppData.Repository;

namespace JogoJustoDotNet.Service;

public class EmpresService : IEmpresaRepository
{
    private readonly IEmpresaRepository _empresaRepository;
    public EmpresService(IEmpresaRepository empresaRepository)
    {
        _empresaRepository = empresaRepository;
    }
    public void CriarEmpresa(string inscricaoestadual, string nome, string endereco, string telefone) => _empresaRepository.CriarEmpresa(inscricaoestadual, nome, endereco, telefone);

    public void AtualizarEmpresa(int id, string inscricaoestadual, string nome, string endereco, string telefone) => _empresaRepository.AtualizarEmpresa(id, inscricaoestadual, nome, endereco, telefone);

    public IEnumerable<Models.EmpresaModel> ListarEmpresas() => _empresaRepository.ListarEmpresas();

    public void DeletarEmpresa(int id) => _empresaRepository.DeletarEmpresa(id);

}
