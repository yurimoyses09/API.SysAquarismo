namespace Api.SysAquarismo.Domain.Enum;

public class Enums
{
    /// <summary>
    /// Representa o sexo tanto dos usuarios quando dos peixes
    /// </summary>
    public enum Sexo
    {
        #region [ Pessoa ]
        FEMININO = 1,
        MASCULINO = 2,
        #endregion

        #region [ Animal ]
        MACHO = 3,
        FEMEA = 4
        #endregion
    }

    /// <summary>
    /// Representa o status da saude do peixe
    /// </summary>
    public enum Status_Saude
    {
        SAUDAVEL = 1,
        DOENTE = 2,
        MORTO = 3
    }

    /// <summary>
    /// Representa a situacao do usuario no sistema
    /// </summary>
    public enum Situacao_Usuario
    {
        ATIVO = 1,
        DESLIGADO = 0
    }
}
