using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.SysAquarismo.Domain.Dtos.PeixeDTO;

public class CreatePeixeDTO
{
    [JsonPropertyName("nome_peixe")]
    [Required(ErrorMessage = "O atributo de nome deve ser preenchido")]
    [MaxLength(20, ErrorMessage = "O tamanho do nome nao é valido < 20")]
    public string Ds_Nome_Peixe { get; set; }

    [JsonPropertyName("nome_especie")]
    [Required(ErrorMessage = "O atributo de nome da especie deve ser preenchido")]
    [MaxLength(50, ErrorMessage = "O tamanho do nome da especie nao pode ultrapassar 50 caracteres")]
    public string Ds_Nome_Especie { get; set; }
    [JsonPropertyName("descricao")]
    public string Ds_Descricao { get; set; }

    [JsonPropertyName("id_sexo")]
    [Required(ErrorMessage = "O tamando do atribudo de sexo não pode ultrapassar 5 caracteres")]
    public int Sexo { get; set; }

    [JsonPropertyName("peso")]
    public double? Vl_Peso { get; set; }

    [JsonPropertyName("tamanho")]
    public double? Vl_Tamanho { get; set; }

    [JsonPropertyName("id_status_saude")]
    [Required(ErrorMessage = "O atribudo de status da saude deve ser preenchido")]
    public int Id_Status_Saude { get; set; }

    [JsonPropertyName("dt_morte")]
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? Ds_Data_Morte { get; set; }

    [JsonPropertyName("ds_doenca")]
    public string Ds_Doenca { get; set; }

    [JsonPropertyName("dt_aquisicao")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "O tribudo de data de aquisição deve ser preenchido")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime Ds_Data_Aquisicao { get; set; }

    [JsonPropertyName("ds_imagem")]
    public string Ds_Imagem { get; set; }

    [JsonPropertyName("id_usuario")]
    public int Id_Usuario { get; set; }
}
