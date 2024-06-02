using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.SysAquarismo.Domain.Dtos.UsuarioDTO;

public class LoginUsuarioDTO
{
    [JsonPropertyName("nome_usuario")]
    [Required(ErrorMessage = "Atribuido nome_usuario deve ser preechido")]
    [MaxLength(50, ErrorMessage = "Valor para o nome_usuario é invalido, não deve ser maior que 50 caracteres")]
    public string Ds_Nome_Usuario_Login { get; set; } = string.Empty;

    [JsonPropertyName("senha")]
    [Required(ErrorMessage = "Atribuido de senha deve ser preenchido")]
    [DataType(DataType.Password)]
    public string Ds_Senha { get; set; } = string.Empty;
}
