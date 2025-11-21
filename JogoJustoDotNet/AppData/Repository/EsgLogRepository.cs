
using Microsoft.EntityFrameworkCore;

namespace JogoJustoDotNet.AppData.Repository;

public class EsgLogRepository : IEsgLogRepository
{
    private readonly JogoDbContext _jogoDbContext;

    public EsgLogRepository(JogoDbContext jogoDbContext)
    {
        _jogoDbContext = jogoDbContext;
    }

    public IEnumerable<string> GetAllEsgCategories()
    {
        _jogoDbContext.ChangeTracker.Clear();
        return _jogoDbContext.EsgLogModel
            .AsNoTracking()
            .Select(e => e.Recomendacao)
            .Distinct()
            .ToList();

    }
}
