using System.Text.Json.Serialization;

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
    public string Sexo { get; set; }
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

    public ReadPeixeDTO(int id_Peixe, int id_Usuario, string ds_Nome_Peixe, string ds_Nome_Especie, string ds_Descricao, string sexo, double vl_Peso, int vl_Tamanho, DateTime ds_Data_Morte, string ds_Imagem, string id_status_Saude, string ds_status_Saude, string ds_doenca, DateTime ds_Data_Aquisicao)
    {
        Id_Peixe = id_Peixe;
        Id_Usuario = id_Usuario;
        Ds_Nome_Peixe = ds_Nome_Peixe;
        Ds_Nome_Especie = ds_Nome_Especie;
        Ds_Descricao = ds_Descricao;
        Sexo = sexo;
        Vl_Peso = vl_Peso;
        Vl_Tamanho = vl_Tamanho;
        Ds_Data_Morte = ds_Data_Morte;
        Ds_Imagem = ds_Imagem;
        Id_status_Saude = id_status_Saude;
        Ds_status_Saude = ds_status_Saude;
        Ds_doenca = ds_doenca;
        Ds_Data_Aquisicao = ds_Data_Aquisicao;
    }
}
