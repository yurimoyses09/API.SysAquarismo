using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Api.SysAquarismo.Domain.Dtos.UsuarioDTO;

public class ResetSenhaUsuarioDTO
{
    [Required(ErrorMessage = "Atribuido nome_usuario deve ser preechido")]
    [MaxLength(50, ErrorMessage = "Valor para o nome_usuario é invalido, não deve ser maior que 50 caracteres")]
    public string nome_login { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Atribuido de senha deve ser preenchido")]
    public string senha { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Atribuido de senha_repetida deve ser preenchido")]
    public string senha_repetida { get; set; } = string.Empty;
}