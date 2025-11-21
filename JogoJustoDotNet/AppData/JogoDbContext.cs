using Microsoft.EntityFrameworkCore;

namespace JogoJustoDotNet.AppData;

public class JogoDbContext : DbContext
{
    public JogoDbContext(DbContextOptions<JogoDbContext> options) : base(options)
    {
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<JogoJustoDotNet.Models.UsuarioModel> Usuario { get; set; }
    public DbSet<JogoJustoDotNet.Models.FuncionarioModel> Funcionario { get; set; }
    public DbSet<JogoJustoDotNet.Models.DepartamentoModel> Departamento { get; set; }
    public DbSet<JogoJustoDotNet.Models.EmpresaModel> Empresa { get; set; }
    public DbSet<JogoJustoDotNet.Models.MetaEsgModel> MetaEsg { get; set; }
    public DbSet<JogoJustoDotNet.Models.EsgLogModel> EsgLogModel { get; set; }

    public DbSet<JogoJustoDotNet.Models.TokensModel> Tokem { get; set; }
}
