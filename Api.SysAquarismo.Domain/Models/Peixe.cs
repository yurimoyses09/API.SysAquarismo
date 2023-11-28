using Api.SysAquarismo.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Api.SysAquarismo.Domain.Models;

public class Peixe
{
    public int Id_Peixe { get; set; }
    public int Id_Usuario { get; set; }
    public string Ds_Nome_Peixe { get; set; }
    public string Ds_Nome_Especie { get; set; }
    public string Ds_Descricao { get; set; }
    public Enums.Sexo Id_Sexo { get; set; }
    public double Vl_Peso { get; set; }
    public int Vl_Tamanho { get; set; }
    public DateTime Ds_Data_Morte { get; set; }
    public string Ds_Imagem { get; set; }
    public Enums.Status_Saude Id_Status_Saude { get; set; }
    public string Ds_Doenca { get; set; }
    public DateTime Ds_Data_Aquisicao { get; set; }

    public Peixe() { }

    public Peixe(int id_Peixe, int id_Usuario, string ds_Nome_Peixe, string ds_Nome_Especie, string ds_Descricao, Enums.Sexo id_Sexo, double vl_Peso, int vl_Tamanho, DateTime ds_Data_Morte, string ds_Imagem, Enums.Status_Saude id_status_Saude, string ds_Doenca, DateTime ds_Data_Aquisicao)
    {
        Id_Peixe = id_Peixe;
        Id_Usuario = id_Usuario;
        Ds_Nome_Peixe = ds_Nome_Peixe;
        Ds_Nome_Especie = ds_Nome_Especie;
        Ds_Descricao = ds_Descricao;
        Id_Sexo = id_Sexo;
        Vl_Peso = vl_Peso;
        Vl_Tamanho = vl_Tamanho;
        Ds_Data_Morte = ds_Data_Morte;
        Ds_Imagem = ds_Imagem;
        Id_Status_Saude = id_status_Saude;
        Ds_Doenca = ds_Doenca;
        Ds_Data_Aquisicao = ds_Data_Aquisicao;
    }
}
