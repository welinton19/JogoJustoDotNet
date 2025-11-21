using JogoJustoDotNet.Models;
using System.ComponentModel.DataAnnotations;

namespace JogoJustoDotNet.ViewModels;

public class DepartamentoViewModel
{
    public int IdDepartamento { get; set; }
    [MaxLength(150)]
    public string NomeDepartamento { get; set; }
    public int GerenteId { get; set; }
    public EmpresaModel Empresa { get; set; }
    public List<FuncionarioModel> Funcionarios { get; set; } = new();
    public List<EsgLogModel> EsgLogs { get; set; } = new();
}
