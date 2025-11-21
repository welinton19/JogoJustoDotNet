using JogoJustoDotNet.AppData.Repository;

namespace JogoJustoDotNet.Service;

public class EsgLogService : IEsgLogRepository
{
    private readonly IEsgLogRepository _esgRepository;

    public EsgLogService(IEsgLogRepository esgRepository)
    {
        _esgRepository = esgRepository;
    }

    IEnumerable<string> IEsgLogRepository.GetAllEsgCategories() => _esgRepository.GetAllEsgCategories();

}
