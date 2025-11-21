using System.ComponentModel.DataAnnotations;

namespace JogoJustoDotNet.Models;

public class TokensModel
{
    internal readonly string Role;

    [Key]
    public int Id { get; set; }
    public string Token { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataExpiracao { get; set; } = DateTime.Now;
}
