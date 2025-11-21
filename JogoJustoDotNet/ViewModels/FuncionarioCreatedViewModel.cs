using JogoJustoDotNet.Models;
using System.ComponentModel.DataAnnotations;

namespace JogoJustoDotNet.ViewModels;

public class FuncionarioCreatedViewModel
{

    public int FuncionarioId { get; set; }
    [Required(ErrorMessage = " O campo Nome é obrigatório")]
    [Display(Name = "Nome Completo")]
    [StringLength(100, ErrorMessage = " O campo Nome deve ter no máximo 100 caracteres")]
    public string Nome { get; set; }
    [Required(ErrorMessage = " Insira uma data válida")]
    [Display(Name = "Data de Nascimento")]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }
    [Required(ErrorMessage = " O campo Gênero é obrigatório")]
    [Display(Name = "Gênero")]
    [StringLength(50, ErrorMessage = " O campo Gênero deve ter no máximo 50 caracteres")]
    public string Genero { get; set; }
    [Required(ErrorMessage = " O campo Cargo é obrigatório")]
    [Display(Name = "Cargo")]
    [StringLength(100, ErrorMessage = " O campo Cargo deve ter no máximo 100 caracteres")]
    public string Cargo { get; set; }
    [Required(ErrorMessage = " Insira uma data válida")]
    [Display(Name = "Data de Contratação")]
    [DataType(DataType.Date)]
    public DateTime DataContratacao { get; set; }
    [Required(ErrorMessage = " O campo Raça é obrigatório")]
    [Display(Name = "Raça")]
    [StringLength(50, ErrorMessage = " O campo Raça deve ter no máximo 50 caracteres")]
    public string Raca { get; set; }
    
    [Display(Name = "Pessoa com Deficiência")]
    public bool StPcd { get; set; }
    [Display(Name = "Tipo de Deficiência")]
    public string TipoPcd { get; set; }
    [Required(ErrorMessage = " O campo CPF é obrigatório")]
    [Display(Name = "CPF")]
    [StringLength(11, ErrorMessage = " O campo CPF deve ter no máximo 11 caracteres")]
    public string Cpf { get; set; }
    [Required(ErrorMessage = " O campo Carga Horária  é obrigatório")]
    [Display(Name = "Carga Horária")]
    [StringLength(20, ErrorMessage = " O campo Carga Horária deve ter no máximo 20 caracteres")]
    public string CargaHoraria { get; set; }
    [Required(ErrorMessage = " O campo Descrição da Carga Horária é obrigatório")]
    [Display(Name = "Descrição da Carga Horária")]
    [StringLength(100, ErrorMessage = " O campo Descrição da Carga Horária deve ter no máximo 100 caracteres")]
    public string DescricaoCargaHoraria { get; set; }
    [Required(ErrorMessage = " O campo Salário é obrigatório")]
    [Display(Name = "Salário")]
    [DataType(DataType.Currency)]
    public decimal Salario { get; set; }
    public FuncionarioModel? Mentor { get; set; }
    public List<FuncionarioModel> Mentorados { get; set; } = new List<FuncionarioModel>();
    public DepartamentoModel Departamento { get; set; }
    public List<DesenvolvimentoModel> Desenvolvimentos { get; set; } = new List<DesenvolvimentoModel>();

    
}
