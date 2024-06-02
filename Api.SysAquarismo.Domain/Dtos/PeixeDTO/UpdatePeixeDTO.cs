using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.SysAquarismo.Domain.Dtos.PeixeDTO;

public class UpdatePeixeDTO
{
    [JsonPropertyName("id_peixe")]
    public int Id_Peixe { get; set; }

    [JsonPropertyName("nome_peixe")]
    [MaxLength(20, ErrorMessage = "O tamanho do nome nao é valido < 20")]
    public string Ds_Nome_Peixe { get; set; } = string.Empty;

    [JsonPropertyName("nome_especie")]
    [MaxLength(50, ErrorMessage = "O tamanho do nome da especie nao pode ultrapassar 50 caracteres")]
    public string Ds_Nome_Especie { get; set; } = string.Empty;

    [JsonPropertyName("descricao")]
    public string? Ds_Descricao { get; set; } = string.Empty;

    [JsonPropertyName("id_sexo")]
    public int Sexo { get; set; }

    [JsonPropertyName("peso")]
    public double? Vl_Peso { get; set; }

    [JsonPropertyName("tamanho")]
    public double? Vl_Tamanho { get; set; }

    [JsonPropertyName("id_status_saude")]
    public int Id_Status_Saude { get; set; }

    [JsonPropertyName("dt_morte")]
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? Ds_Data_Morte { get; set; } = null;

    [JsonPropertyName("ds_doenca")]
    public string? Ds_Doenca { get; set; } = string.Empty;

    [JsonPropertyName("dt_aquisicao")]
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? Ds_Data_Aquisicao { get; set; } = null;

    [JsonPropertyName("ds_imagem")]
    public string? Ds_Imagem { get; set; } = string.Empty;

    [JsonPropertyName("id_usuario")]
    public int Id_Usuario { get; set; }
}
