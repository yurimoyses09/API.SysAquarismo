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

    [JsonPropertyName("sexo")]
    [MaxLength(5, ErrorMessage = "O tamando do atribudo de sexo não pode ultrapassar 5 caracteres")]
    public string Sexo { get; set; }

    [JsonPropertyName("peso")]
    public double Vl_Peso { get; set; }

    [JsonPropertyName("tamanho")]
    public double Vl_Tamanho { get; set; }

    [JsonPropertyName("status_saude")]
    [Required(ErrorMessage = "O atribudo de status da saude deve ser preenchido")]
    public string Ds_status_Saude { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    [JsonPropertyName("dt_morte")]
    public DateTime Ds_Data_Morte { get; set; }

    [JsonPropertyName("ds_doenca")]
    public string Ds_doenca { get; set; }

    [JsonPropertyName("dt_aquisicao")]
    [Required(ErrorMessage = "Oa tribudo de data de aquisição deve ser preenchido")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime Ds_Data_Aquisicao { get; set; }

    [JsonPropertyName("ds_imagem")]
    public string Ds_Imagem { get; set; }

    [JsonPropertyName("id_usuario")]
    public int Id_Usuario { get; set; }

    public CreatePeixeDTO(string ds_Nome_Peixe, string ds_Nome_Especie, string ds_Descricao, string sexo, double vl_Peso, double vl_Tamanho, string ds_status_Saude, DateTime ds_Data_Morte, string ds_doenca, DateTime ds_Data_Aquisicao, string ds_Imagem, int id_Usuario)
    {
        Ds_Nome_Peixe = ds_Nome_Peixe;
        Ds_Nome_Especie = ds_Nome_Especie;
        Ds_Descricao = ds_Descricao;
        Sexo = sexo;
        Vl_Peso = vl_Peso;
        Vl_Tamanho = vl_Tamanho;
        Ds_status_Saude = ds_status_Saude;
        Ds_Data_Morte = ds_Data_Morte;
        Ds_doenca = ds_doenca;
        Ds_Data_Aquisicao = ds_Data_Aquisicao;
        Ds_Imagem = ds_Imagem;
        Id_Usuario = id_Usuario;
    }
}
