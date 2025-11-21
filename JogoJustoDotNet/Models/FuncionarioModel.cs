using System.ComponentModel.DataAnnotations;

namespace JogoJustoDotNet.Models;

public class FuncionarioModel
{
    [Key]
    public int FuncionarioId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Genero { get; set; }
    public string Cargo { get; set; }
    public DateTime DataContratacao { get; set; }
    public string Raca{ get; set; }
    public bool StPcd { get; set; }
    public string TipoPcd { get; set; }
    [Required]
    [MaxLength(16)]
    public string Cpf { get; set; }
    public string CargaHoraria { get; set; }
    public string DescricaoCargaHoraria { get; set; }
    public decimal Salario { get; set; }
    public FuncionarioModel? Mentor { get; set; }
    public List<FuncionarioModel> Mentorados { get; set; } = new List<FuncionarioModel>();
    public DepartamentoModel Departamento { get; set; }
    public List<DesenvolvimentoModel> Desenvolvimentos { get; set; } = new List<DesenvolvimentoModel>();

}
