namespace Api.SysAquarismo.Infrastructure.Querys;

public static class PeixeDQ
{
    internal static string BuscaDadosPeixeLogin()
    {
        return @$"
                SELECT
                	   [ID_PEIXE] AS Id_Peixe
                  ,[NOME] AS Ds_Nome_Peixe
                  ,[ESPECIE] AS Ds_Nome_Especie
                  ,[DB_SYSAQUARISMO_DEV].[dbo].[TB_STATUS_SAUDE].[ID_STATUS_SAUDE] AS Id_status_Saude
                  ,[ID_USUARIO] AS Id_Usuario
	                ,[DB_SYSAQUARISMO_DEV].[dbo].[TB_SEXO].[ID_SEXO] AS Sexo 
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
            	   [ID_PEIXE] AS Id_Peixe
                  ,[NOME] AS Ds_Nome_Peixe
                  ,[ESPECIE] AS Ds_Nome_Especie
                  ,[DS_PEIXE] AS Ds_Descricao
                  ,[dbo].[TB_PEIXE].[ID_SEXO] AS Sexo
                  ,[DS_STATUS_SAUDE] AS Ds_status_Saude
                  ,[PESO] AS Vl_Peso
                  ,[TAMANHO] AS Vl_Tamanho
                  ,[DT_MORTE] AS Ds_Data_Morte
                  ,[DS_DOENCA] AS Ds_doenca
                  ,[DB_SYSAQUARISMO_DEV].[dbo].[TB_STATUS_SAUDE].[ID_STATUS_SAUDE] AS Id_status_Saude
                  ,[DT_AQUISICAO] AS Ds_Data_Aquisicao
                  ,[IMG_PEIXE]
                  ,[ID_USUARIO] AS Id_Usuario
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
                      @nome
                    , @especie
                    , @descrisao
                    , @sexo
                    , @status_saude
                    , @peso
                    , @tamanho
                    , @data_morte
                    , @doenca
                    , @data_aquisicao
                    , @imagem
                    , @id_usuario
                   )";
    }
}