using JogoJustoDotNet.AppData.Repository;
using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.Service;

public class MetaEsgService : IMetaEsgRepository
{
   private readonly IMetaEsgRepository _metaEsgRepository;

    public MetaEsgService(IMetaEsgRepository metaEsgRepository)
    {
        _metaEsgRepository = metaEsgRepository;
    }

    public void AtualizarMetaEsg(MetaEsgModel metaEsg) => _metaEsgRepository.AtualizarMetaEsg(metaEsg);


    public void CriarMetaEsg(MetaEsgModel metaEsg) => _metaEsgRepository.CriarMetaEsg(metaEsg);


    public void DeletarMetaEsg(int id) => _metaEsgRepository.DeletarMetaEsg(id);


    public IEnumerable<MetaEsgModel> ListarMetasEsg() => _metaEsgRepository.ListarMetasEsg();


    public MetaEsgModel ObterMetaEsgPorId(int id) => _metaEsgRepository.ObterMetaEsgPorId(id);

}
