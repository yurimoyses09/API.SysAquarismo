namespace Api.SysAquarismo.Infrastructure.Querys;

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
    internal static string BuscaDadosUsuario()
    {
        return @$"
            SELECT
                 U.[ID_USUARIO] AS id_usuario
                ,U.[NOME] AS nome_usuario
                ,U.[IDADE] AS idade
                ,U.[TELEFONE] AS telefone
                ,U.[NOME_LOGIN] AS nome_login
            	,P.[ID_PEIXE] AS id_peixe
                ,P.[NOME] AS nome_peixe
                ,P.[ESPECIE] AS nome_especie
                ,P.[ID_USUARIO] AS id_usuario
                ,STS.[ID_STATUS_SAUDE] AS id_saude
                ,S.[ID_SEXO] AS sexo 
            FROM [dbo].[TB_USUARIO] U
            
            INNER JOIN [dbo].[TB_PEIXE] P ON
            	P.[ID_USUARIO] = U.[ID_USUARIO]
            
            INNER JOIN [dbo].[TB_SEXO] S ON
                 S.[ID_SEXO] = P.[ID_SEXO]
            
            INNER JOIN [dbo].[TB_STATUS_SAUDE] STS ON
                 STS.[ID_STATUS_SAUDE] = P.[ID_STATUS_SAUDE]
            
            WHERE [NOME_LOGIN] = @nome_login";
    }

    /// <summary>
    /// Busca nome de login na base para evitar usuarios com o mesmo login
    /// </summary>
    /// <param name="usuario"></param>
    /// <returns></returns>
    internal static string BuscaExistenciaLogin()
    {
        return $@"
            SELECT 
                [NOME_LOGIN] AS nome_login
            FROM [dbo].[TB_USUARIO] 
            WHERE 
                [NOME_LOGIN] = @nome_login AND
                [USUARIO_ATIVO] = @usuario_ativo";
    }

    /// <summary>
    /// Realiza busca na base para validação de login
    /// </summary>
    /// <param name="usuario"></param>
    /// <returns></returns>
    internal static string BuscaUsuarioLogin()
    {
        return $@"
            SELECT 
                 [ID_USUARIO] AS id_usuario
                ,[NOME] AS nome_usuario
                ,[IDADE] AS idade
                ,[TELEFONE] AS telefone
                ,[NOME_LOGIN] AS nome_login
                ,[SENHA] AS senha
                ,[SENHA_COFIRMADA] AS senha
            FROM [dbo].[TB_USUARIO] 
            WHERE 
                [NOME_LOGIN] = @nome_login AND
                [SENHA] = @senha AND
                [USUARIO_ATIVO] = @usuario_ativo";
    }

    /// <summary>
    /// Query que cria usuario no sistema
    /// </summary>
    /// <param name="usuario"></param>
    /// <returns></returns>
    internal static string QueryCriaUsuario()
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
                   ,[DS_EMAIL]
                   ,[USUARIO_ATIVO]
                   ,[DT_INCLUSAO])
             VALUES
                   (
                         @nome_usuario
                        ,@idade
                        ,@telefone
                        ,@sexo
                        ,@pais
                        ,@nome_login
                        ,@senha
                        ,@senha_repetida
                        ,@email
                        ,@status_usuario
                        ,@dt_inclusao
                   )";
    }
}