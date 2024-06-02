namespace Api.SysAquarismo.Domain.Models;

public class Peixe
{
    public int Id_Peixe { get; set; }
    public int Id_Usuario { get; set; }
    public string Ds_Nome_Peixe { get; set; }
    public string Ds_Nome_Especie { get; set; }
    public string Ds_Descricao { get; set; }
    public int Sexo { get; set; }
    public double Vl_Peso { get; set; }
    public int Vl_Tamanho { get; set; }
    public DateTime? Ds_Data_Morte { get; set; } = null;
    public string Ds_Imagem { get; set; }
    public int Id_Status_Saude { get; set; }
    public string Ds_Doenca { get; set; }
    public DateTime? Ds_Data_Aquisicao { get; set; } = null;

    public Peixe() { }
}
