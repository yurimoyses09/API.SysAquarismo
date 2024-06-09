using Api.SysAquarismo.Domain.Models;

namespace Api.SysAquarismo.Domain.Dtos.UsuarioDTO;

public class GetUsuarioDTO
{
    public GetUsuarioDTO() { }

    public GetUsuarioDTO(int id_Usuario, string nome_Usuario, int idade, string ds_Telefone, string ds_Email, string ds_Nome_Usuario_Login, string ds_Senha, string sexo, string ds_Pais, List<Peixe> peixes)
    {
        Id_Usuario = id_Usuario;
        nome_usuario = nome_Usuario;
        idade = idade;
        telefone = ds_Telefone;
        email = ds_Email;
        nome_login = ds_Nome_Usuario_Login;
        senha = ds_Senha;
        sexo = sexo;
        pais = ds_Pais;
        peixes = peixes;
    }

    public int Id_Usuario { get; set; }
    public string nome_usuario { get; set; }
    public int idade { get; set; }
    public string telefone { get; set; }
    public string email { get; set; }
    public string nome_login { get; set; }
    public string senha { get; set; }
    public int sexo { get; set; }
    public string pais { get; set; }
    public List<Peixe> peixes { get; set; }
}
