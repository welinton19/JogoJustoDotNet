using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.AppData.Repository;

public class MetaEsgRepository : IMetaEsgRepository
{
    
    private readonly JogoDbContext _jogoDbContext;

    public MetaEsgRepository(JogoDbContext jogoDbContext)
    {
        _jogoDbContext = jogoDbContext;
    }

    public void AtualizarMetaEsg(MetaEsgModel metaEsg)
    {
        _jogoDbContext.MetaEsg.Update(metaEsg);
        _jogoDbContext.SaveChanges();
    }

    public void CriarMetaEsg(MetaEsgModel metaEsg)
    {
        _jogoDbContext.MetaEsg.Add(metaEsg);
        _jogoDbContext.SaveChanges();
    }

    public void DeletarMetaEsg(int id)
    {
        _jogoDbContext.ChangeTracker.Clear();
        var metaEsg = _jogoDbContext.MetaEsg.FirstOrDefault(m => m.IdMetaEsg == id);
        if (metaEsg != null)
        {
            _jogoDbContext.MetaEsg.Remove(metaEsg);
            _jogoDbContext.SaveChanges();
        }

    }

    public IEnumerable<MetaEsgModel> ListarMetasEsg()
    {
        _jogoDbContext.ChangeTracker.Clear();
        return _jogoDbContext.MetaEsg.ToList();
    }

    public MetaEsgModel ObterMetaEsgPorId(int id)
    {
        _jogoDbContext.ChangeTracker.Clear();
        return _jogoDbContext.MetaEsg.FirstOrDefault(m => m.IdMetaEsg == id);

    }
}
