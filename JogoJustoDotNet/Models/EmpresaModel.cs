using System.ComponentModel.DataAnnotations;

namespace JogoJustoDotNet.Models;

public class EmpresaModel
{
    [Key]
    public int EmpresaId { get; set; }
    public string InscricaoEstadual { get; set; }
    public string Nome { get; set; }
    
    public string Endereco { get; set; }
    [Phone]
    public string Telefone { get; set; }

    public List<DepartamentoModel> Departamentos { get; set; } = new List<DepartamentoModel>();
    public List<MetaEsgModel> MetasEsg { get; set; } = new List<MetaEsgModel>();


}
