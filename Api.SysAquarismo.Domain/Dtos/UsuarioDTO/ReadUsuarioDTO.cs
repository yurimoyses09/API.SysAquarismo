using Api.SysAquarismo.Domain.Dtos.PeixeDTO;
using static Api.SysAquarismo.Domain.Enum.Enums;

namespace Api.SysAquarismo.Domain.Dtos.UsuarioDTO;

public class ReadUsuarioDTO
{
    public int id_usuario { get; set; }
    public string nome_usuario { get; set; }
    public int idade { get; set; }
    public string tefelone { get; set; }
    public string email { get; set; }
    public string nome_login { get; set; }
    public string senha { get; set; }
    public Sexo sexo { get; set; }
    public string pais { get; set; }
    public List<ReadPeixeDTO> peixes { get; set; }
}
