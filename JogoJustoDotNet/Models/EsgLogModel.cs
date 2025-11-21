using System.ComponentModel.DataAnnotations;

namespace JogoJustoDotNet.Models;

public class EsgLogModel
{
    [Key]
    public int IdEsgLog { get; set; }
    public DepartamentoModel Departamento { get; set; }
    public string AcaoRealizada { get; set; }
    public string Recomendacao { get; set; }
    public DateTime DataAcao { get; set; }
}
