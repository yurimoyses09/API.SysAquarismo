using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Api.SysAquarismo.Domain.Dtos.UsuarioDTO;

public class ResetSenhaUsuarioDTO
{
    [JsonProperty("nome_usuario")]
    [Required(ErrorMessage = "Atribuido nome_usuario deve ser preechido")]
    [MaxLength(50, ErrorMessage = "Valor para o nome_usuario é invalido, não deve ser maior que 50 caracteres")]
    public string Nome_Usuario { get; set; } = string.Empty;

    [JsonProperty("senha")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Atribuido de senha deve ser preenchido")]
    public string Senha { get; set; } = string.Empty;

    [JsonProperty("senha_repetida")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Atribuido de senha_repetida deve ser preenchido")]
    public string Senha_Repetida { get; set; } = string.Empty;
}