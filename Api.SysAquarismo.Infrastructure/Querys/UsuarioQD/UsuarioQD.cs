using Api.SysAquarismo.Domain.Enum;
using Api.SysAquarismo.Domain.Models.Usuario;

namespace Api.SysAquarismo.Infrastructure.Querys.UsuarioQD;

/// <summary>
/// Centralizadora de consultas na base de dados relacionada ao usuario
/// </summary>
public static class UsuarioQD
{
    /// <summary>
    /// Busca nome de login na base para evitar usuarios com o mesmo login
    /// </summary>
    /// <param name="usuario"></param>
    /// <returns></returns>
    internal static string BuscaExistenciaLogin(Usuario usuario)
    {
        return $@"
            SELECT 
                 [ID_USUARIO]
                ,[NOME]
                ,[IDADE]
                ,[TELEFONE]
                ,[ID_SEXO]
                ,[PAIS]
                ,[NOME_LOGIN]
                ,[SENHA]
                ,[SENHA_COFIRMADA]
                ,[ID_PEIXE]
            FROM [dbo].[TB_USUARIO] 
            WHERE 
                [NOME_LOGIN] = '{usuario.Ds_Nome_Usuario_Login}'";
    }

    /// <summary>
    /// Realiza busca na base para validação de login
    /// </summary>
    /// <param name="usuario"></param>
    /// <returns></returns>
    internal static string BuscaUsuarioLogin(Usuario usuario)
    {
        return $@"
            SELECT 
                 [ID_USUARIO]
                ,[NOME]
                ,[IDADE]
                ,[TELEFONE]
                ,[ID_SEXO]
                ,[PAIS]
                ,[NOME_LOGIN]
                ,[SENHA]
                ,[SENHA_COFIRMADA]
                ,[ID_PEIXE]
            FROM [dbo].[TB_USUARIO] 
            WHERE 
                [NOME_LOGIN] = '{usuario.Ds_Nome_Usuario_Login}' AND
                [SENHA] = '{usuario.Ds_Senha}'";
    }

    /// <summary>
    /// Query que cria usuario no sistema
    /// </summary>
    /// <param name="usuario"></param>
    /// <returns></returns>
    internal static string QueryCriaUsuario(Usuario usuario)
    {
        return $@"
            INSERT INTO [dbo].[TB_USUARIO]
                   ([NOME]
                   ,[IDADE]
                   ,[TELEFONE]
                   ,[ID_SEXO]
                   ,[PAIS]
                   ,[NOME_LOGIN]
                   ,[SENHA]
                   ,[SENHA_COFIRMADA])
             VALUES
                   ('{usuario.Nome_Usuario}'
                   ,{usuario.Idade}
                   ,'{usuario.Ds_Telefone}'
                   ,{(int)Enum.Parse(typeof(Enums.Status_Saude), usuario.Sexo)}
                   ,'{usuario.Ds_Pais}'
                   ,'{usuario.Ds_Nome_Usuario_Login}'
                   ,'{usuario.Ds_Senha}'
                   ,'{usuario.Ds_Senha}')";
    }
}