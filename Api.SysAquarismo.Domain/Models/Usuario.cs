using static Api.SysAquarismo.Domain.Enum.Enums;

namespace Api.SysAquarismo.Domain.Models;

public class Usuario
{
    public int Id_Usuario { get; set; }
    public string Nome_Usuario { get; set; }
    public int Idade { get; set; }
    public string Ds_Telefone { get; set; }
    public string Ds_Email { get; set; }
    public string Ds_Nome_Usuario_Login { get; set; }
    public string Ds_Senha { get; set; }
    public Sexo Sexo { get; set; }
    public string Ds_Pais { get; set; }
    public List<Peixe> Peixes { get; set; }

    public Usuario() { }

    public Usuario(int id_Usuario, string nome_Usuario, int idade, string ds_Telefone, string ds_Email, string ds_Nome_Usuario_Login, string ds_Senha, Sexo sexo, string ds_Pais, List<Peixe> peixes)
    {
        Id_Usuario = id_Usuario;
        Nome_Usuario = nome_Usuario;
        Idade = idade;
        Ds_Telefone = ds_Telefone;
        Ds_Email = ds_Email;
        Ds_Nome_Usuario_Login = ds_Nome_Usuario_Login;
        Ds_Senha = ds_Senha;
        Sexo = sexo;
        Ds_Pais = ds_Pais;
        Peixes = peixes;
    }

    public Usuario(IEnumerable<Peixe> peixe, Usuario usuario)
    {
        Id_Usuario = usuario.Id_Usuario;
        Nome_Usuario = usuario.Nome_Usuario.ToString();
        Ds_Telefone = usuario.Ds_Telefone.ToString();
        Idade = usuario.Idade;
        Ds_Nome_Usuario_Login = usuario.Ds_Nome_Usuario_Login;
        Peixes = new List<Peixe>();

        foreach (Peixe pe in peixe)
        {
            Peixes.Add(pe);
        } 
    }
}
