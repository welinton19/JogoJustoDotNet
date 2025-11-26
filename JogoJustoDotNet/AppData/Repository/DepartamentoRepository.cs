using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.AppData.Repository;

public class DepartamentoRepository : IDepartamentoRepository
{
    private readonly JogoDbContext _jogoDbContext;

    public DepartamentoRepository(JogoDbContext jogoDbContext)
    {
        _jogoDbContext = jogoDbContext;
    }

    public void CreateDepartamento(DepartamentoModel departamento)
    {
        _jogoDbContext.Departamento.Add(departamento);
        _jogoDbContext.SaveChanges();

    }

    public void DeleteDepartamentoModel(int id)
    {
        _jogoDbContext.ChangeTracker.Clear();
        var departamento = _jogoDbContext.Departamento.FirstOrDefault(d => d.IdDepartamento == id);
        if (departamento != null)
        {
            _jogoDbContext.Departamento.Remove(departamento);
            _jogoDbContext.SaveChanges();
        }

    }

    public void DeleteDepartamentoModel(DepartamentoModel departamento)
    {
        _jogoDbContext.ChangeTracker.Clear();
        _jogoDbContext.Departamento.Remove(departamento);
        _jogoDbContext.SaveChanges();
    }

    public IEnumerable<DepartamentoModel> GetAllDepartamentos()
    {
        _jogoDbContext.ChangeTracker.Clear();
        return _jogoDbContext.Departamento.ToList();
    }

    public DepartamentoModel GetDepartamentoById(int id)
    {
        _jogoDbContext.ChangeTracker.Clear();
        return _jogoDbContext.Departamento.FirstOrDefault(d => d.IdDepartamento == id);
    }

    public void UpdateDepartamento(DepartamentoModel departamento)
    {
        _jogoDbContext.ChangeTracker.Clear();
        _jogoDbContext.Departamento.Update(departamento);
        _jogoDbContext.SaveChanges();

    }
}
