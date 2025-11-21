using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.Service;

public interface IMetaEsgService
{
    void CriarMetaEsg(MetaEsgModel metaEsg);
    void AtualizarMetaEsg(MetaEsgModel metaEsg);
    MetaEsgModel ObterMetaEsgPorId(int id);
    IEnumerable<MetaEsgModel> ListarMetasEsg();
    void DeletarMetaEsg(int id);
}
