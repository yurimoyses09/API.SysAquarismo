﻿using Api.SysAquarismo.Domain.Enum;
using Api.SysAquarismo.Domain.Models.Usuario;

namespace Api.SysAquarismo.Infrastructure.Querys.UsuarioQD;

public static class UsuarioQD
{
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