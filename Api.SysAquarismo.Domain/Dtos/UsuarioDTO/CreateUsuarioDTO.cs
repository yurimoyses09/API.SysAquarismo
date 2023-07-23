using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Api.SysAquarismo.Domain.Dtos.UsuarioDTO;

public class CreateUsuarioDTO
{
    [JsonProperty("nome")]
    [Required(ErrorMessage = "Atribuido de nome deve ser preenchido")]
    [MaxLength(100, ErrorMessage = "Valor para o nome é invalido, não deve ser maior que 100 caracteres")]
    public string Nome { get; set; }

    [JsonProperty("idade")]
    [Required(ErrorMessage = "Atribudo de idade deve ser preenchido")]
    [Range(0, 100, ErrorMessage = "Valor de idade é invalido")]
    public int Idade { get; set; }

    [JsonProperty("telefone")]
    public string Telefone { get; set; }

    [JsonProperty("sexo")]
    [Required(ErrorMessage = "Atribuido de sexo deve ser preenchido")]
    public string Sexo { get; set; }

    [JsonProperty("pais")]
    public string Pais { get; set; }

    [JsonProperty("nome_usuario")]
    [Required(ErrorMessage = "Atribuido nome_usuario deve ser preechido")]
    [MaxLength(50, ErrorMessage = "Valor para o nome_usuario é invalido, não deve ser maior que 50 caracteres")]
    public string Nome_Usuario { get; set; }

    [JsonProperty("senha")]
    [Required(ErrorMessage = "Atribuido de senha deve ser preenchido")]
    public string Senha { get; set; }

    [JsonProperty("senha_repetida")]
    [Required(ErrorMessage = "Atribuido de senha_repetida deve ser preenchido")]
    public string Senha_Repetida { get; set; }

    public CreateUsuarioDTO() { }

    public CreateUsuarioDTO(string nome, int idade, string telefone, string sexo, string pais, string nome_Usuario, string senha, string senha_Repetida)
    {
        Nome = nome;
        Idade = idade;
        Telefone = telefone;
        Sexo = sexo;
        Pais = pais;
        Nome_Usuario = nome_Usuario;
        Senha = senha;
        Senha_Repetida = senha_Repetida;
    }
}
