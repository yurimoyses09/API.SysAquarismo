namespace Api.SysAquarismo.Domain.Models.Usuario;

public class Usuario
{
    public int Id { get; set; }
    public string Nome_Usuario { get; set; }
    public int Idade { get; set; }
    public string Ds_Telefone { get; set; }
    public string  Ds_Email { get; set; }
    public string Ds_Nome_Usuario_Login { get; set; }
    public string Ds_Senha { get; set; }
    public string Sexo { get; set; }
    public string Ds_Pais { get; set; }
    public IEnumerable<Peixe.Peixe> Peixes { get; set; }

    public Usuario()
    {
    
    }

    public Usuario(int id, string nome_Usuario, int idade, string ds_Telefone, string ds_Email, string ds_Nome_Usuario_Login, string ds_Senha, string sexo, string ds_Pais, IEnumerable<Peixe.Peixe> peixes)
    {
        Id = id;
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
}
