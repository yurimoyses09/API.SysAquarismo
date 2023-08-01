using Api.SysAquarismo.Domain.Enum;
using Api.SysAquarismo.Domain.Models;

namespace Api.SysAquarismo.Infrastructure.Querys.PeixeQD
{
    public static class PeixeDQ
    {
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
                   ,[IMG_PEIXE])
             VALUES
                   (
                      '{peixe.Ds_Nome_Peixe}'
                    , '{peixe.Ds_Nome_Especie}'
                    , '{peixe.Ds_Descricao}'
                    ,  {(int)Enum.Parse(typeof(Enums.Sexo), peixe.Sexo)}
                    ,  {(int)Enum.Parse(typeof(Enums.Status_Saude), peixe.Ds_status_Saude)}
                    ,  {peixe.Vl_Peso}
                    ,  {peixe.Vl_Tamanho}
                    , '{peixe.Ds_Data_Morte}'
                    , '{peixe.Ds_doenca}'
                    , '{peixe.Ds_Data_Aquisicao}'
                    , '{peixe.Ds_Imagem}'
                   )";
        }
    }
}