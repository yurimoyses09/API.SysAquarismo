using Api.SysAquarismo.Domain.Models;

namespace Api.SysAquarismo.Domain.Dtos.UsuarioDTO;

public class GetUsuarioDTO
{
    public GetUsuarioDTO() { }

    public GetUsuarioDTO(int id_Usuario, string nome_Usuario, int idade, string ds_Telefone, string ds_Email, string ds_Nome_Usuario_Login, string ds_Senha, string sexo, string ds_Pais, List<Peixe> peixes)
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

    public int Id_Usuario { get; set; }
    public string Nome_Usuario { get; set; }
    public int Idade { get; set; }
    public string Ds_Telefone { get; set; }
    public string Ds_Email { get; set; }
    public string Ds_Nome_Usuario_Login { get; set; }
    public string Ds_Senha { get; set; }
    public string Sexo { get; set; }
    public string Ds_Pais { get; set; }
    public List<Peixe> Peixes { get; set; }
}
