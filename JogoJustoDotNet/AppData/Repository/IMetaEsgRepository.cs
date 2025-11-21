using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.AppData.Repository;

public interface IMetaEsgRepository
{
    void CriarMetaEsg(MetaEsgModel metaEsg);
    void AtualizarMetaEsg(MetaEsgModel metaEsg);
    MetaEsgModel ObterMetaEsgPorId(int id);
    IEnumerable<MetaEsgModel> ListarMetasEsg();
    void DeletarMetaEsg(int id);
}
