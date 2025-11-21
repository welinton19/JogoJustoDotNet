using JogoJustoDotNet.Models;

namespace JogoJustoDotNet.AppData.Repository;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly JogoDbContext _jogoDbContext;

    public FuncionarioRepository(JogoDbContext jogoDbContext)
    {
        _jogoDbContext = jogoDbContext;
    }

    public void AtualizarFuncionario(int id, string nome, string cargo, decimal salario)
    {
        _jogoDbContext.ChangeTracker.Clear();
        var funcionario = _jogoDbContext.Funcionario.FirstOrDefault(f => f.FuncionarioId == id);
        if (funcionario != null)
        {
            funcionario.Nome = nome;
            funcionario.Cargo = cargo;
            funcionario.Salario = salario;
            _jogoDbContext.SaveChanges();
        }

    }

    public void CriarFuncionario(string nome, string cargo, decimal salario)
    {
        _jogoDbContext.Funcionario.Add(new FuncionarioModel
        {
            Nome = nome,
            Cargo = cargo,
            Salario = salario
        });
        _jogoDbContext.SaveChanges();
    }

    public void DeletarFuncionario(int id)
    {
        _jogoDbContext.ChangeTracker.Clear();
        var funcionario = _jogoDbContext.Funcionario.FirstOrDefault(f => f.FuncionarioId == id);
        if (funcionario != null)
        {
            _jogoDbContext.Funcionario.Remove(funcionario);
            _jogoDbContext.SaveChanges();
        }

    }

    public IEnumerable<FuncionarioModel> ListarFuncionarios()
    {
        _jogoDbContext.ChangeTracker.Clear();
        return _jogoDbContext.Funcionario.ToList();

    }

    public FuncionarioModel ObterFuncionario(int id)
    {
        _jogoDbContext.ChangeTracker.Clear();
        return _jogoDbContext.Funcionario.FirstOrDefault(f => f.FuncionarioId == id);

    }
}
