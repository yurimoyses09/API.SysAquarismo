using System.ComponentModel.DataAnnotations;

namespace Api.SysAquarismo.Domain.Models;

public class Peixe
{
    public int Id_Peixe { get; set; }
    public int Id_Usuario { get; set; }
    public string Ds_Nome_Peixe { get; set; }
    public string Ds_Nome_Especie { get; set; }
    public string Ds_Descricao { get; set; }
    public string Sexo { get; set; }
    public double Vl_Peso { get; set; }
    public int Vl_Tamanho { get; set; }
    public DateTime Ds_Data_Morte { get; set; }
    public string Ds_Imagem { get; set; }
    public string Ds_status_Saude { get; set; }
    public int Id_status_Saude { get; set; }
    public string Ds_doenca { get; set; }
    public DateTime Ds_Data_Aquisicao { get; set; }

    public Peixe() { }

    public Peixe(int id_Saude, int id, int id_Usuario, string ds_Nome_Peixe, string ds_Nome_Especie, string ds_Descricao, string sexo, double vl_Peso, int vl_Tamanho, DateTime ds_Data_Morte, string ds_Imagem, string ds_status_Saude, string ds_doenca, DateTime ds_Data_Aquisicao)
    {
        Id_Peixe = id;
        Id_Usuario = id_Usuario;
        Ds_Nome_Peixe = ds_Nome_Peixe;
        Ds_Nome_Especie = ds_Nome_Especie;
        Ds_Descricao = ds_Descricao;
        Sexo = sexo;
        Vl_Peso = vl_Peso;
        Vl_Tamanho = vl_Tamanho;
        Ds_Data_Morte = ds_Data_Morte;
        Ds_Imagem = ds_Imagem;
        Ds_status_Saude = ds_status_Saude;
        Ds_doenca = ds_doenca;
        Ds_Data_Aquisicao = ds_Data_Aquisicao;
        Id_status_Saude = id_Saude;
    }
}
