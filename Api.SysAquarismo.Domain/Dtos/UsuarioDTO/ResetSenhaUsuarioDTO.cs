﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Api.SysAquarismo.Domain.Dtos.UsuarioDTO;

public class ResetSenhaUsuarioDTO
{
    [JsonProperty("nome_usuario")]
    [Required(ErrorMessage = "Atribuido nome_usuario deve ser preechido")]
    [MaxLength(50, ErrorMessage = "Valor para o nome_usuario é invalido, não deve ser maior que 50 caracteres")]
    public string Nome_Usuario { get; set; }

    [JsonProperty("senha")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Atribuido de senha deve ser preenchido")]
    public string Senha { get; set; }

    [JsonProperty("senha_repetida")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Atribuido de senha_repetida deve ser preenchido")]
    public string Senha_Repetida { get; set; }

    public ResetSenhaUsuarioDTO(string nome_Usuario, string senha, string senha_Repetida)
    {
        Nome_Usuario = nome_Usuario;
        Senha = senha;
        Senha_Repetida = senha_Repetida;
    }
}