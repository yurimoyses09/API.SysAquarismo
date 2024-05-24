using Api.SysAquarismo.Domain.Dtos.PeixeDTO;
using System.Text.Json.Serialization;
using static Api.SysAquarismo.Domain.Enum.Enums;

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
    public Sexo Sexo { get; set; }
    [JsonPropertyName("pais")]
    public string Ds_Pais { get; set; }
    [JsonPropertyName("peixes")]
    public List<ReadPeixeDTO> Peixes { get; set; }
}
