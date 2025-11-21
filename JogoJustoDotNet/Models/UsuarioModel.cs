using System.ComponentModel.DataAnnotations;

namespace JogoJustoDotNet.Models;

public class UsuarioModel
{


    [Key]
    public int Id { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
  
    public string Tipo { get; set; } = string.Empty;
}
