using Api.SysAquarismo.Domain.Enum;
using Api.SysAquarismo.Domain.Models;

namespace Api.SysAquarismo.Infrastructure.Querys.UsuarioQD;

/// <summary>
/// Centralizadora de consultas na base de dados relacionada ao usuario
/// </summary>
public static class UsuarioQD
{
    /// <summary>
    /// Busca todos os dados do usuario em base dados
    /// </summary>
    /// <param name="nome_usuario"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    internal static string BuscaDadosUsuario(string nome_usuario)
    {
        return @$"
            SELECT TOP (1) 
                 [ID_USUARIO] AS Id_Usuario
                ,[NOME] AS Nome_Usuario
                ,[IDADE] AS Idade
                ,[TELEFONE] AS Ds_Telefone
                ,[NOME_LOGIN] AS Ds_Nome_Usuario_Login
            FROM [DB_SYSAQUARISMO_DEV].[dbo].[TB_USUARIO]
            WHERE [NOME_LOGIN] = '{nome_usuario}'";
    }

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
                   ,[SENHA_COFIRMADA]
                   ,[EMAIL])
             VALUES
                   ('{usuario.Nome_Usuario}'
                   ,{usuario.Idade}
                   ,'{usuario.Ds_Telefone}'
                   ,{(int)Enum.Parse(typeof(Enums.Sexo), usuario.Sexo)}
                   ,'{usuario.Ds_Pais}'
                   ,'{usuario.Ds_Nome_Usuario_Login}'
                   ,'{usuario.Ds_Senha}'
                   ,'{usuario.Ds_Senha}'
                   ,'{usuario.Ds_Email}')";
    }
}