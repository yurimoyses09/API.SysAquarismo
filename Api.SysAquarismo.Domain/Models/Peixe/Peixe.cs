using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.SysAquarismo.Domain.Models.Peixe;

public class Peixe
{
    [Key]
    public int Id { get; set; }
    [ForeignKey(nameof(Id_Usuario))]
    public int Id_Usuario { get; set; }
    [Required]
    public string Ds_Nome_Peixe { get; set; }
    [Required]
    public string Ds_Nome_Especie { get; set; }
    public string Ds_Descricao { get; set; }
    public double? Vl_Peso { get; set; }
    public int? Vl_Tamanho { get; set; }
    public DateTime? Ds_Data_Morte { get; set; }
    public byte[] Ds_Imagem { get; set; }
    public string Ds_status_Saude { get; set; }
    public string Ds_doenca { get; set; }
    [Required]
    public DateTime Ds_Data_Aquisicao { get; set; }
    public virtual Usuario.Usuario Usuario { get; set; }

    public Peixe()
    {
        
    }

    public Peixe(int id, int id_Usuario, string ds_Nome_Peixe, string ds_Nome_Especie, string ds_Descricao, double? vl_Peso, int? vl_Tamanho, DateTime? ds_Data_Morte, byte[] ds_Imagem, string ds_status_Saude, string ds_doenca, DateTime ds_Data_Aquisicao, Usuario.Usuario usuario)
    {
        Id = id;
        Id_Usuario = id_Usuario;
        Ds_Nome_Peixe = ds_Nome_Peixe;
        Ds_Nome_Especie = ds_Nome_Especie;
        Ds_Descricao = ds_Descricao;
        Vl_Peso = vl_Peso;
        Vl_Tamanho = vl_Tamanho;
        Ds_Data_Morte = ds_Data_Morte;
        Ds_Imagem = ds_Imagem;
        Ds_status_Saude = ds_status_Saude;
        Ds_doenca = ds_doenca;
        Ds_Data_Aquisicao = ds_Data_Aquisicao;
        Usuario = usuario;
    }
}
