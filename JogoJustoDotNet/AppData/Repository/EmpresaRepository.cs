using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.AppData.Repository;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly JogoDbContext _jogoDbContext;

    public EmpresaRepository(JogoDbContext jogoDbContext)
    {
        _jogoDbContext = jogoDbContext;
    }

    public void AtualizarEmpresa(int id, string inscricaoestadual, string nome, string endereco, string telefone)
    {
        _jogoDbContext.ChangeTracker.Clear();
        var empresa = _jogoDbContext.Empresa.FirstOrDefault(e => e.EmpresaId == id);
        if (empresa != null) 
        {
            empresa.InscricaoEstadual = inscricaoestadual;
            empresa.Nome = nome;
            empresa.Endereco = endereco;
            empresa.Telefone = telefone;
            _jogoDbContext.Empresa.Update(empresa);
            _jogoDbContext.SaveChanges();
        }
    }

    public void CriarEmpresa(string inscricaoestadual, string nome, string endereco, string telefone)
    {
        _jogoDbContext.ChangeTracker.Clear();
        var empresa = new EmpresaModel
        {
            InscricaoEstadual = inscricaoestadual,
            Nome = nome,
            Endereco = endereco,
            Telefone = telefone
        };
        _jogoDbContext.Empresa.Add(empresa);
        _jogoDbContext.SaveChanges();
    }

    public void DeletarEmpresa(int id)
    {
        _jogoDbContext.ChangeTracker.Clear();
        var empresa = _jogoDbContext.Empresa.FirstOrDefault(e => e.EmpresaId == id);
        if (empresa != null) 
        {
            _jogoDbContext.Empresa.Remove(empresa);
            _jogoDbContext.SaveChanges();
        }
    }

    public IEnumerable<EmpresaModel> ListarEmpresas()
    {
        _jogoDbContext.ChangeTracker.Clear();
        return _jogoDbContext.Empresa.ToList();
    }
}
