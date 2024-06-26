﻿using Api.SysAquarismo.Domain.Dtos.UsuarioDTO;
using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models;
using Api.SysAquarismo.Domain.Responses;
using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.SysAquarismo.Application.Controllers;

[ApiController]
[Produces("application/json")]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/usuario")]
public class UsuarioController(IMapper mapper, IUsuarioRepository repository, ILogger<UsuarioController> logger) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly IUsuarioRepository _repository = repository;
    private readonly ILogger<UsuarioController> _logger = logger;

    /// <summary>
    /// Cadastra usuario no sistema
    /// </summary>
    /// <param name="createUsuario">Dados usados para realizar cadastro no sistema</param>
    /// <returns></returns>
    /// <response code="201">Usuario cadastrado com sucesos</response>
    /// <response code="400">Falha ao cadastrar usuario</response>
    [HttpPost("cadastra")]
    [ProducesResponseType(typeof(Response<CreateUsuarioDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Cadastra([FromBody] CreateUsuarioDTO createUsuario)
    {
        try
        {
            _logger.LogInformation("Dados recebidos no request!");

            Usuario usuario = _mapper.Map<Usuario>(createUsuario);

            _logger.LogInformation("Buscando usuario com o mesmo login!");
            IEnumerable<Usuario> validacao = await _repository.BuscaMesmoLogin(usuario);
            
            if (validacao.Any()) 
            {
                _logger.LogWarning("O usuario informado ja possui conta no sistema!");
                return Ok(new Response<CreateUsuarioDTO>(createUsuario, $"Nome de login {createUsuario.nome_login} já existe!"));
            }

            await _repository.InsertUsuario(usuario);
            _logger.LogInformation("Usuario criado com sucesso no sistema!");

            return Ok(new Response<CreateUsuarioDTO>(createUsuario, "Usuario criado com sucesso no sistema!"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message); 
            return BadRequest(new Response<CreateUsuarioDTO?>(null, ex.Message));
        }
    }

    /// <summary>
    /// Realiza login no sistema
    /// </summary>
    /// <param name="loginUsuario">Dados usados para validar login no sistema</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Usuario cadastrado com sucesos</response>
    /// <response code="400">Falha ao cadastrar usuario</response>
    /// <response code="404">Usuario não cadastrado no sistema</response>
    [HttpPost("login")]
    [ProducesResponseType(typeof(Response<LoginUsuarioDTO?>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login([FromBody] LoginUsuarioDTO loginUsuario)
    {
        try
        {
            _logger.LogInformation("Dados recebidos no request!");

            Usuario usuario = _mapper.Map<Usuario>(loginUsuario);

            _logger.LogInformation("Efetuando login no sistema!");
            IEnumerable<Usuario> usuarioValido = await _repository.LoginUsuario(usuario);

            if (usuarioValido != null && usuarioValido.Any()) 
            {
                _logger.LogInformation("Login efetuado com sucesso!");
                return Ok(new Response<LoginUsuarioDTO?>(loginUsuario, "Login efetuado com sucesso!"));
            }
            else 
            {
                _logger.LogWarning("Usuario não cadastrado no sistema!");
                return NotFound(new Response<LoginUsuarioDTO?>(loginUsuario, "Usuario não cadastrado no sistema!"));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(new Response<LoginUsuarioDTO?>(null, ex.Message));
        }
    }

    /// <summary>
    /// Busca todos os dados do usuario e os peixes relacionados a ele
    /// </summary>
    /// <param name="nome_login"></param>
    /// <returns></returns>
    [HttpGet("{nome_login}")]
    [ProducesResponseType(typeof(Response<LoginUsuarioDTO?>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> BuscaUsuarioPorNomeLogin(string nome_login)
    {
        try
        {
            _logger.LogInformation("Dados recebidos no request!");

            _logger.LogInformation("Buscando dados no usuario no sistema!");
            var result = await _repository.BuscaDadosUsuario(nome_login);

            if (result == null)
                return NotFound(new Response<ReadUsuarioDTO>(null, "Usuario nao foi encontrado no sistema"));

            ReadUsuarioDTO dados = _mapper.Map<ReadUsuarioDTO>(result.FirstOrDefault());

            _logger.LogInformation("Dados recuperados com sucesso!");
            return Ok(new Response<ReadUsuarioDTO?>(dados, "Dados recuperados com sucesso!"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(new Response<ReadUsuarioDTO?>(null, ex.Message));
        }
    }

    #region [ Endpoints nao implementados ainda ]

    /// <summary>
    /// Valida existencia de usuario para redefinir senha
    /// </summary>
    /// <param name="nome_usuario">Nome do usuario para realizar validação no sistema</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Usuario existe no sistema</response>
    /// <response code="400">Falha ao buscar usuario</response>
    /// <response code="404">Usuario não localizado</response>
    [HttpGet("valida_usuario/{nome_usuario}")]
    public async Task<IActionResult> Valida(string nome_usuario)
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { data = ex.Message });
        }
    }

    /// <summary>
    /// Realiza Updade de senha do Usuario
    /// </summary>
    /// <param name="resetSenhaUsuario"></param>
    /// <returns></returns>
    /// <response code="201">Senha atualizada com sucesso</response>
    /// <response code="400">Falha ao atualizar senha</response>
    [HttpPut("reset_senha")]
    public async Task<IActionResult> ResetSenha([FromBody] ResetSenhaUsuarioDTO resetSenhaUsuario)
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { data = ex.Message });
        }
    }

    #endregion
}
