using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.SysAquarismo.Domain.Dtos.PeixeDTO;

public class CreatePeixeDTO
{
    [Required(ErrorMessage = "O atributo de nome deve ser preenchido")]
    [MaxLength(20, ErrorMessage = "O tamanho do nome nao é valido < 20")]
    public string nome_peixe { get; set; }

    [Required(ErrorMessage = "O atributo de nome da especie deve ser preenchido")]
    [MaxLength(50, ErrorMessage = "O tamanho do nome da especie nao pode ultrapassar 50 caracteres")]
    public string nome_especie { get; set; }
    
    public string descricao { get; set; }

    [Required(ErrorMessage = "O tamando do atribudo de sexo não pode ultrapassar 5 caracteres")]
    public int sexo { get; set; }

    public double? peso { get; set; }

    public double? tamanho { get; set; }

    [Required(ErrorMessage = "O atribudo de status da saude deve ser preenchido")]
    public int id_saude { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? dt_morte { get; set; } = null;

    public string ds_doenca { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "O tribudo de data de aquisição deve ser preenchido")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? dt_aquisicao { get; set; } = null;

    public string? ds_imagem { get; set; } = string.Empty;

    public int id_usuario { get; set; }
}
