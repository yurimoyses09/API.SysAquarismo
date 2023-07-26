using Api.SysAquarismo.Domain.Enum;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Api.SysAquarismo.Domain.Dtos.UsuarioDTO;

public class CreateUsuarioDTO
{
    [JsonProperty("nome")]
    [Required(ErrorMessage = "Atribuido de nome deve ser preenchido")]
    [MaxLength(100, ErrorMessage = "Valor para o nome é invalido, não deve ser maior que 100 caracteres")]
    public string Nome_Usuario { get; set; }

    [JsonProperty("idade")]
    [Required(ErrorMessage = "Atribudo de idade deve ser preenchido")]
    [Range(0, 100, ErrorMessage = "Valor de idade é invalido")]
    public int Idade { get; set; }

    [JsonProperty("telefone")]
    public string Ds_Telefone { get; set; }

    [JsonProperty("sexo")]
    [Required(ErrorMessage = "Atribuido de sexo deve ser preenchido")]
    public Sexo Id_Sexo { get; set; }

    [JsonProperty("pais")]
    public string Ds_Pais { get; set; }

    [JsonProperty("nome_usuario")]
    [Required(ErrorMessage = "Atribuido nome_usuario deve ser preechido")]
    [MaxLength(50, ErrorMessage = "Valor para o nome_usuario é invalido, não deve ser maior que 50 caracteres")]
    public string Ds_Nome_Usuario { get; set; }

    [JsonProperty("senha")]
    [Required(ErrorMessage = "Atribuido de senha deve ser preenchido")]
    public string Ds_Senha { get; set; }

    public CreateUsuarioDTO(string nome_Usuario, int idade, string ds_Telefone, Sexo id_Sexo, string ds_Pais, string ds_Nome_Usuario, string ds_Senha)
    {
        Nome_Usuario = nome_Usuario;
        Idade = idade;
        Ds_Telefone = ds_Telefone;
        Id_Sexo = id_Sexo;
        Ds_Pais = ds_Pais;
        Ds_Nome_Usuario = ds_Nome_Usuario;
        Ds_Senha = ds_Senha;
    }
}
