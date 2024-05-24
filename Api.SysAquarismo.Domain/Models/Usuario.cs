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
    public int Sexo { get; set; }
    public string Ds_Pais { get; set; }
    public List<Peixe> Peixes { get; set; }

    public Usuario() { }

    public Usuario(IEnumerable<Peixe> peixe, Usuario usuario)
    {
        Id_Usuario = usuario.Id_Usuario;
        Nome_Usuario = usuario.Nome_Usuario.ToString();
        Ds_Telefone = usuario.Ds_Telefone.ToString();
        Idade = usuario.Idade;
        Ds_Nome_Usuario_Login = usuario.Ds_Nome_Usuario_Login;
        Peixes = new List<Peixe>();

        foreach (Peixe pe in peixe)
            Peixes.Add(pe);
    }
}
