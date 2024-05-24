using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.SysAquarismo.Domain.Dtos.UsuarioDTO;

public class CreateUsuarioDTO
{
    [JsonPropertyName("nome_usuario")]
    [Required(ErrorMessage = "Atribuido de nome deve ser preenchido")]
    [MaxLength(100, ErrorMessage = "Valor para o nome é invalido, não deve ser maior que 100 caracteres")]
    public string Nome_Usuario { get; set; }

    [JsonPropertyName("idade")]
    [Required(ErrorMessage = "Atribudo de idade deve ser preenchido")]
    [Range(0, 100, ErrorMessage = "Valor de idade é invalido")]
    public int Idade { get; set; }

    [JsonPropertyName("telefone")]
    [DataType(DataType.PhoneNumber)]
    public string Ds_Telefone { get; set; }

    [JsonPropertyName("email")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "O campo email precisa ser preenchido")]
    public string Ds_Email { get; set; }

    [JsonPropertyName("sexo")]
    [Required(ErrorMessage = "Atribuido de sexo deve ser preenchido")]
    public int Sexo { get; set; }

    [JsonPropertyName("pais")]
    public string Ds_Pais { get; set; }

    [JsonPropertyName("nome_usuario_login")]
    [Required(ErrorMessage = "Atribuido nome_usuario deve ser preechido")]
    [MaxLength(50, ErrorMessage = "Valor para o nome_usuario é invalido, não deve ser maior que 50 caracteres")]
    public string Ds_Nome_Usuario_Login { get; set; }

    [JsonPropertyName("senha")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Atribuido de senha deve ser preenchido")]
    public string Ds_Senha { get; set; }
}