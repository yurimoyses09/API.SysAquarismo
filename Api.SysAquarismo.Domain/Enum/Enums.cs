using System.ComponentModel;

namespace Api.SysAquarismo.Domain.Enum;

public class Enums
{
    /// <summary>
    /// Representa o sexo tanto dos usuarios quando dos peixes
    /// </summary>
    public enum Sexo
    {
        #region [ Pessoa ]
        [Description("FEMININO")]
        FEMININO = 1,

        [Description("MASCULINO")]
        MASCULINO = 2,
        #endregion

        #region [ Animal ]
        [Description("MACHO")]
        MACHO = 3,

        [Description("FEMEA")]
        FEMEA = 4
        #endregion
    }

    /// <summary>
    /// Representa o status da saude do peixe
    /// </summary>
    public enum Status_Saude
    {
        [Description("SAUDAVEL")]
        SAUDAVEL = 1,

        [Description("DOENTE")]
        DOENTE = 2,

        [Description("MORTO")]
        MORTO = 3
    }

    /// <summary>
    /// Representa a situacao do usuario no sistema
    /// </summary>
    public enum Situacao_Usuario
    {
        [Description("ATIVO")]
        ATIVO = 1,

        [Description("DESLIGADO")]
        DESLIGADO = 0
    }
}
