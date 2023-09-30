using Api.SysAquarismo.Domain.Models;

namespace Api.SysAquarismo.Domain.Dtos.UsuarioDTO;

public class GetUsuarioDTO
{
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
