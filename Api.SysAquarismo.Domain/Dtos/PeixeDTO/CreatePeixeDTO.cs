using Api.SysAquarismo.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Api.SysAquarismo.Domain.Dtos.PeixeDTO;

public class CreatePeixeDTO
{
    [Required(ErrorMessage = "O atributo de nome deve ser preenchido")]
    [MaxLength(20, ErrorMessage = "O tamanho do nome nao é valido <20")]
    public string Ds_Nome_Peixe { get; set; }

    [Required(ErrorMessage = "O atributo de nome da especie deve ser preenchido")]
    [MaxLength(50, ErrorMessage = "O tamanho do nome da especie nao pode ultrapassar 50 caracteres")]
    public string Ds_Nome_Especie { get; set; }
    public string Ds_Descricao { get; set; }
    public Sexo Id_Sexo { get; set; }
    public double Vl_Peso { get; set; }
    public double Vl_Tamanho { get; set; }

    [Required(ErrorMessage = "O atribudo de status da saude deve ser preenchido")]
    public string Ds_status_Saude { get; set; }
    public DateTime Ds_Data_Morte { get; set; }
    public string Ds_doenca { get; set; }

    [Required(ErrorMessage = "Oa tribudo de data de aquisição deve ser preenchido")]
    public DateTime Ds_Data_Aquisicao { get; set; }
    public string Ds_Imagem { get; set; }

    public CreatePeixeDTO(string ds_Nome_Peixe, string ds_Nome_Especie, string ds_Descricao, Sexo id_Sexo, double vl_Peso, double vl_Tamanho, string ds_status_Saude, DateTime ds_Data_Morte, string ds_doenca, DateTime ds_Data_Aquisicao, string ds_Imagem)
    {
        Ds_Nome_Peixe = ds_Nome_Peixe;
        Ds_Nome_Especie = ds_Nome_Especie;
        Ds_Descricao = ds_Descricao;
        Id_Sexo = id_Sexo;
        Vl_Peso = vl_Peso;
        Vl_Tamanho = vl_Tamanho;
        Ds_status_Saude = ds_status_Saude;
        Ds_Data_Morte = ds_Data_Morte;
        Ds_doenca = ds_doenca;
        Ds_Data_Aquisicao = ds_Data_Aquisicao;
        Ds_Imagem = ds_Imagem;
    }
}
