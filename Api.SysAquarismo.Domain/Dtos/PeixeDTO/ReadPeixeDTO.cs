using System.Text.Json.Serialization;
using static Api.SysAquarismo.Domain.Enum.Enums;

namespace Api.SysAquarismo.Domain.Dtos.PeixeDTO;

public class ReadPeixeDTO
{
    public int id_peixe { get; set; }
    public int id_usuario { get; set; }
    public string nome_peixe { get; set; }
    public string nome_especie { get; set; }
    public string descricao { get; set; }
    public Sexo sexo { get; set; }
    public double peso { get; set; }
    public int tamanho { get; set; }
    public DateTime dt_morte { get; set; }
    public string ds_imagem { get; set; }
    public string id_saude { get; set; }
    public string ds_saude { get; set; }
    public string ds_doenca { get; set; }
    public DateTime dt_aquisicao { get; set; }
}
