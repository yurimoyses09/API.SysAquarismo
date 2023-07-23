using System.ComponentModel.DataAnnotations;

namespace Api.SysAquarismo.Domain.Models.Usuario;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Nome_Usuario { get; set; }
    [Required]
    public int Idade { get; set; }
    public string Ds_Telefone { get; set; }
    [Required]
    public string Ds_Nome_Usuario { get; set; }
    [Required]
    public string Ds_Senha { get; set; }
    [Required]
    public string Ds_Sexo { get; set; }
    [Required]
    public string Ds_Pais { get; set; }
    public IEnumerable<Peixe.Peixe> Peixes { get; set; }

    public Usuario()
    {
        
    }

    public Usuario(int id, string nome_Usuario, int idade, string ds_Telefone, string ds_Nome_Usuario, string ds_Senha, string ds_Sexo, string ds_Pais, IEnumerable<Peixe.Peixe> peixes)
    {
        Id = id;
        Nome_Usuario = nome_Usuario;
        Idade = idade;
        Ds_Telefone = ds_Telefone;
        Ds_Nome_Usuario = ds_Nome_Usuario;
        Ds_Senha = ds_Senha;
        Ds_Sexo = ds_Sexo;
        Ds_Pais = ds_Pais;
        Peixes = peixes;
    }
}
