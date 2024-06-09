using System.ComponentModel.DataAnnotations;

namespace Api.SysAquarismo.Domain.Dtos.PeixeDTO;

public class UpdatePeixeDTO
{
    public int id_peixe { get; set; }

    [MaxLength(20, ErrorMessage = "O tamanho do nome nao é valido < 20")]
    public string nome_peixe { get; set; } = string.Empty;

    [MaxLength(50, ErrorMessage = "O tamanho do nome da especie nao pode ultrapassar 50 caracteres")]
    public string nome_especie { get; set; } = string.Empty;

    public string? descricao { get; set; } = string.Empty;

    public int sexo { get; set; }

    public double? peso { get; set; }

    public double? tamanho { get; set; }

    public int id_saude { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? dt_morte { get; set; } = null;

    public string? ds_doenca { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? dt_aquisicao { get; set; } = null;

    public string? ds_imagem { get; set; } = string.Empty;
    public int id_usuario { get; set; }
}
