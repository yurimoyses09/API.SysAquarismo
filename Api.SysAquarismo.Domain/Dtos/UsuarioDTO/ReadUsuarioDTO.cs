using Api.SysAquarismo.Domain.Dtos.PeixeDTO;
using System.Text.Json.Serialization;

namespace Api.SysAquarismo.Domain.Dtos.UsuarioDTO;

public class ReadUsuarioDTO
{
    [JsonPropertyName("id_usuario")]
    public int Id_Usuario { get; set; }
    [JsonPropertyName("nome_usuario")]
    public string Nome_Usuario { get; set; }
    [JsonPropertyName("idade")]
    public int Idade { get; set; }
    [JsonPropertyName("tefelone")]
    public string Ds_Telefone { get; set; }
    [JsonPropertyName("email")]
    public string Ds_Email { get; set; }
    [JsonPropertyName("nome_login")]
    public string Ds_Nome_Usuario_Login { get; set; }
    [JsonPropertyName("senha_usuario")]
    public string Ds_Senha { get; set; }
    [JsonPropertyName("sexo")]
    public string Sexo { get; set; }
    [JsonPropertyName("pais")]
    public string Ds_Pais { get; set; }
    [JsonPropertyName("peixes")]
    public List<ReadPeixeDTO> Peixes { get; set; }

    public ReadUsuarioDTO()
    {
        
    }

    public ReadUsuarioDTO(int id_Usuario, string nome_Usuario, int idade, string ds_Telefone, string ds_Email, string ds_Nome_Usuario_Login, string ds_Senha, string sexo, string ds_Pais, List<ReadPeixeDTO> peixes)
    {
        Id_Usuario = id_Usuario;
        Nome_Usuario = nome_Usuario;
        Idade = idade;
        Ds_Telefone = ds_Telefone;
        Ds_Email = ds_Email;
        Ds_Nome_Usuario_Login = ds_Nome_Usuario_Login;
        Ds_Senha = ds_Senha;
        Sexo = sexo;
        Ds_Pais = ds_Pais;
        Peixes = peixes;
    }
}
