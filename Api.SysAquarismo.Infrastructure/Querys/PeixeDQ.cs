namespace Api.SysAquarismo.Infrastructure.Querys;

public static class PeixeDQ
{
    internal static string BuscaDadosPeixeLogin()
    {
        return @$"
                SELECT
                   [ID_PEIXE] AS id_peixe
                  ,[NOME] AS nome_peixe
                  ,[ESPECIE] AS nome_especie
                  ,[DB_SYSAQUARISMO_DEV].[dbo].[TB_STATUS_SAUDE].[ID_STATUS_SAUDE] AS id_saude
                  ,[ID_USUARIO] AS id_usuario
	              ,[DB_SYSAQUARISMO_DEV].[dbo].[TB_SEXO].[ID_SEXO] AS sexo 
                FROM [DB_SYSAQUARISMO_DEV].[dbo].[TB_PEIXE]
                INNER JOIN [DB_SYSAQUARISMO_DEV].[dbo].[TB_SEXO] ON
                [DB_SYSAQUARISMO_DEV].[dbo].[TB_SEXO].[ID_SEXO] = [DB_SYSAQUARISMO_DEV].[dbo].[TB_PEIXE].[ID_SEXO]

                INNER JOIN [DB_SYSAQUARISMO_DEV].[dbo].[TB_STATUS_SAUDE] ON
                [DB_SYSAQUARISMO_DEV].[dbo].[TB_STATUS_SAUDE].[ID_STATUS_SAUDE] = [DB_SYSAQUARISMO_DEV].[dbo].[TB_PEIXE].[ID_STATUS_SAUDE]
                WHERE [ID_USUARIO] = @id_usuario";
    }

    internal static string BuscaDadosPeixe()
    {
        return @$"
                SELECT
            	   [ID_PEIXE] AS id_peixe
                  ,[NOME] AS nome_peixe
                  ,[ESPECIE] AS nome_especie
                  ,[DS_PEIXE] AS descricao
                  ,[dbo].[TB_PEIXE].[ID_SEXO] AS sexo
                  ,[DS_STATUS_SAUDE] AS Ds_status_Saude
                  ,[PESO] AS peso
                  ,[TAMANHO] AS tamanho
                  ,[DT_MORTE] AS dt_morte
                  ,[DS_DOENCA] AS Ds_doenca
                  ,[DB_SYSAQUARISMO_DEV].[dbo].[TB_STATUS_SAUDE].[ID_STATUS_SAUDE] AS id_saude
                  ,[DT_AQUISICAO] AS dt_aquisicao
                  ,[IMG_PEIXE] AS ds_imagem
                  ,[ID_USUARIO] AS id_usuario
                FROM [DB_SYSAQUARISMO_DEV].[dbo].[TB_PEIXE]
                INNER JOIN [DB_SYSAQUARISMO_DEV].[dbo].[TB_SEXO] ON
                [DB_SYSAQUARISMO_DEV].[dbo].[TB_SEXO].[ID_SEXO] = [DB_SYSAQUARISMO_DEV].[dbo].[TB_PEIXE].[ID_SEXO]

                INNER JOIN [DB_SYSAQUARISMO_DEV].[dbo].[TB_STATUS_SAUDE] ON
                [DB_SYSAQUARISMO_DEV].[dbo].[TB_STATUS_SAUDE].[ID_STATUS_SAUDE] = [DB_SYSAQUARISMO_DEV].[dbo].[TB_PEIXE].[ID_STATUS_SAUDE]
              WHERE [ID_PEIXE] = @id_peixe";
    }

    internal static string QueryCriaPeixe()
    {
        return @$"
                INSERT INTO [dbo].[TB_PEIXE]
                   ([NOME]
                   ,[ESPECIE]
                   ,[DS_PEIXE]
                   ,[ID_SEXO]
                   ,[ID_STATUS_SAUDE]
                   ,[PESO]
                   ,[TAMANHO]
                   ,[DT_MORTE]
                   ,[DS_DOENCA]
                   ,[DT_AQUISICAO]
                   ,[IMG_PEIXE]
                   ,[ID_USUARIO])
             VALUES
                   (
                      @nome_peixe
                    , @nome_especie
                    , @descricao
                    , @sexo
                    , @id_saude
                    , @peso
                    , @tamanho
                    , @dt_morte
                    , @ds_doenca
                    , @dt_aquisicao
                    , @ds_imagem
                    , @id_usuario
                   )";
    }

    internal static string QueryDeletaPeixe()
    {
        return @"DELETE FROM [dbo].[TB_PEIXE] WHERE ID_PEIXE = @id_peixe";
    }

    internal static string QueryUpdatePeixe()
    {
        return @"
               UPDATE [dbo].[TB_PEIXE]
               SET [NOME] = @nome_peixe
                  ,[ESPECIE] = @nome_especie
                  ,[DS_PEIXE] = @descricao
                  ,[ID_SEXO] = @sexo
                  ,[ID_STATUS_SAUDE] = @id_saude
                  ,[PESO] = @peso
                  ,[TAMANHO] = @tamanho
                  ,[DT_MORTE] = @dt_morte
                  ,[DS_DOENCA] = @ds_doenca
                  ,[DT_AQUISICAO] = @dt_aquisicao
                  ,[IMG_PEIXE] = @ds_imagem
               WHERE [ID_PEIXE] = @id_peixe
        ";
    }
}