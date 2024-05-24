using System.Text.Json.Serialization;
using static Api.SysAquarismo.Domain.Enum.Enums;

namespace Api.SysAquarismo.Domain.Dtos.PeixeDTO;

public class ReadPeixeDTO
{
    [JsonPropertyName("id_peixe")]
    public int Id_Peixe { get; set; }
    [JsonPropertyName("id_usuario")]
    public int Id_Usuario { get; set; }
    [JsonPropertyName("nome_peixe")]
    public string Ds_Nome_Peixe { get; set; }
    [JsonPropertyName("nome_especie")]
    public string Ds_Nome_Especie { get; set; }
    [JsonPropertyName("descricao")]
    public string Ds_Descricao { get; set; }
    [JsonPropertyName("sexo")]
    public Sexo Sexo { get; set; }
    [JsonPropertyName("peso")]
    public double Vl_Peso { get; set; }
    [JsonPropertyName("tamenho")]
    public int Vl_Tamanho { get; set; }
    [JsonPropertyName("dt_morte")]
    public DateTime Ds_Data_Morte { get; set; }
    [JsonPropertyName("ds_imagem")]
    public string Ds_Imagem { get; set; }
    [JsonPropertyName("id_saude")]
    public string Id_status_Saude { get; set; }
    [JsonPropertyName("ds_saude")]
    public string Ds_status_Saude { get; set; }
    [JsonPropertyName("ds_doenca")]
    public string Ds_doenca { get; set; }
    [JsonPropertyName("dt_aquisicao")]
    public DateTime Ds_Data_Aquisicao { get; set; }
}
