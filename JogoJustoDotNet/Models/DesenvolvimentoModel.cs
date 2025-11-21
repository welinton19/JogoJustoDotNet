using System.ComponentModel.DataAnnotations;

namespace JogoJustoDotNet.Models;

public class DesenvolvimentoModel
{
    [Key]
    public int IdDesenvolvimento { get; set; }
    public string TipoRegistro { get; set; }
    public string DescricaoRegistro { get; set; }
    public string NomeTreinamento { get; set; }
    public string Treinamento { get; set; }
    public DateTime DataConclusao { get; set; }
    public decimal DuracaoHoras { get; set; }
    public byte[] Orgao { get; set; }
    public DateTime DataRegistroDeDados { get; set; }
    public string StatusRegistro { get; set; }
    public FuncionarioModel Funcionario { get; set; }

}
