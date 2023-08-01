using Api.SysAquarismo.Domain.Enum;
using Api.SysAquarismo.Domain.Models.Usuario;

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
                SELECT 
                	Usuario.ID_USUARIO AS Id_Usuario,
                	Usuario.NOME AS Nome_Login,
                	Usuario.IDADE AS Idade,
                	Usuario.TELEFONE AS Tefelone,
                	Usuario.NOME_LOGIN AS Ds_Nome_Usuario_Login,
                
                	Peixes.ID_PEIXE AS Id_Peixe,
                	Peixes.NOME AS Ds_Nome_Peixe,
                	Peixes.ESPECIE AS Ds_Nome_Especie,
                	Peixes.TAMANHO AS Vl_Tamanho, 
                	Peixes.DT_MORTE AS Ds_Data_Morte,
                	Peixes.IMG_PEIXE AS Ds_Imagem,
                	Peixes.DS_DOENCA AS Ds_doenca,
                	Peixes.DT_AQUISICAO AS Ds_Data_Aquisicao
                FROM
                	[dbo].[TB_USUARIO] Usuario
                LEFT JOIN [dbo].[TB_PEIXE] Peixes ON
                Peixes.ID_USUARIO = Usuario.ID_USUARIO
                
                WHERE Usuario.[NOME_LOGIN] = '{nome_usuario}'";
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