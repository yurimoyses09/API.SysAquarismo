using Api.SysAquarismo.Domain.Enum;
using Api.SysAquarismo.Domain.Models;

namespace Api.SysAquarismo.Infrastructure.Querys.PeixeQD
{
    public static class PeixeDQ
    {
        internal static string BuscaDadosPeixe(int id_usuario)
        {
            return @$"
                SELECT
            	   [ID_PEIXE] AS Id_Peixe
                  ,[NOME] AS Ds_Nome_Peixe
                  ,[ESPECIE] AS Ds_Nome_Especie
                  ,[DS_PEIXE] AS Ds_Descricao
                  ,[DS_SEXO] AS Sexo
                  ,[DS_STATUS_SAUDE] AS Ds_status_Saude
                  ,[PESO] AS Vl_Peso
                  ,[TAMANHO] AS Vl_Tamanho
                  ,[DT_MORTE] AS Ds_Data_Morte
                  ,[DS_DOENCA] AS Ds_doenca
                  ,[DT_AQUISICAO] AS Ds_Data_Aquisicao
                  ,[IMG_PEIXE]
                  ,[ID_USUARIO] AS Id_Usuario
                FROM [DB_SYSAQUARISMO_DEV].[dbo].[TB_PEIXE]
                INNER JOIN [DB_SYSAQUARISMO_DEV].[dbo].[TB_SEXO] ON
                [DB_SYSAQUARISMO_DEV].[dbo].[TB_SEXO].[ID_SEXO] = [DB_SYSAQUARISMO_DEV].[dbo].[TB_PEIXE].[ID_SEXO]

                INNER JOIN [DB_SYSAQUARISMO_DEV].[dbo].[TB_STATUS_SAUDE] ON
                [DB_SYSAQUARISMO_DEV].[dbo].[TB_STATUS_SAUDE].[ID_STATUS_SAUDE] = [DB_SYSAQUARISMO_DEV].[dbo].[TB_PEIXE].[ID_STATUS_SAUDE]
              WHERE [ID_USUARIO] = {id_usuario}";
        }

        internal static string QueryCriaPeixe(Peixe peixe)
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
                      '{peixe.Ds_Nome_Peixe}'
                    , '{peixe.Ds_Nome_Especie}'
                    , '{peixe.Ds_Descricao}'
                    ,  {(int)Enum.Parse(typeof(Enums.Sexo), peixe.Sexo)}
                    ,  {(int)Enum.Parse(typeof(Enums.Status_Saude), peixe.Ds_status_Saude)}
                    ,  {peixe.Vl_Peso}
                    ,  {peixe.Vl_Tamanho}
                    , '{DateTime.Parse(Convert.ToString(peixe.Ds_Data_Morte)):yyyy-MM-dd}'
                    , '{peixe.Ds_doenca}'
                    , '{DateTime.Parse(Convert.ToString(peixe.Ds_Data_Aquisicao)):yyyy-MM-dd}'
                    , '{peixe.Ds_Imagem}'
                    ,  {peixe.Id_Usuario}
                   )";
        }
    }
}