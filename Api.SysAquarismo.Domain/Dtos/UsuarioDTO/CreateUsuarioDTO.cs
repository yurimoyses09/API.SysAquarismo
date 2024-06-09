using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.SysAquarismo.Domain.Dtos.UsuarioDTO;

public class CreateUsuarioDTO
{
    [Required(ErrorMessage = "Atribuido de nome deve ser preenchido")]
    [MaxLength(100, ErrorMessage = "Valor para o nome é invalido, não deve ser maior que 100 caracteres")]
    public string nome_usuario { get; set; }

    [Required(ErrorMessage = "Atribudo de idade deve ser preenchido")]
    [Range(0, 100, ErrorMessage = "Valor de idade é invalido")]
    public int idade { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string telefone { get; set; }

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "O campo email precisa ser preenchido")]
    public string email { get; set; }

    [Required(ErrorMessage = "Atribuido de sexo deve ser preenchido")]
    public int sexo { get; set; }

    [JsonPropertyName("pais")]
    public string pais { get; set; }

    [Required(ErrorMessage = "Atribuido nome_usuario deve ser preechido")]
    [MaxLength(50, ErrorMessage = "Valor para o nome_usuario é invalido, não deve ser maior que 50 caracteres")]
    public string nome_login { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Atribuido de senha deve ser preenchido")]
    public string senha { get; set; }
}