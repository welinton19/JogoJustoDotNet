using System.ComponentModel.DataAnnotations;

namespace JogoJustoDotNet.ViewModels;

public class UsuarioViewModel
{

    public int Id { get; set; }
    [Required(ErrorMessage = " O campo Email é obrigatório")]
    [Display(Name =" Email")]
    [EmailAddress(ErrorMessage = " O campo Email deve ser um endereço de email válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = " O campo Senha é obrigatório")]
    [Display(Name = " Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = " O campo Tipo de Usuário é obrigatório")]
    [Display(Name = " Tipo de Usuário")]
    [StringLength(20, ErrorMessage = " O campo Tipo de Usuário deve ter no máximo 20 caracteres")]
    public string Tipo { get; set; } = string.Empty;
}

public enum TipoUsuario
{
    Administrador,
    Gerente,
    Funcionario
}
