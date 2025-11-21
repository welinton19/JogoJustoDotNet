namespace JogoJustoDotNet.AppData.Repository;

public interface IEsgLogRepository
{
    IEnumerable<string> GetAllEsgCategories();
}
