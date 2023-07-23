using Api.SysAquarismo.Domain.Dtos.UsuarioDTO;
using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models.Usuario;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.SysAquarismo.Application.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/v1/usuario")]
public class UsuarioController : ControllerBase
{
    readonly private IMapper _mapper;
    readonly private IUsuarioRepository _repository;

    public UsuarioController(IMapper mapper, IUsuarioRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }


    /// <summary>
    /// Cadastra usuario no sistema
    /// </summary>
    /// <param name="createUsuario"></param>
    /// <returns></returns>
    /// <response code="201">Usuario cadastrado com sucesos</response>
    /// <response code="400">Falha ao cadastrar usuario</response>
    [HttpPost("cadastra")]
    public async Task<IActionResult> Cadastra([FromBody] CreateUsuarioDTO createUsuario)
    {
        try
        {
            Usuario usuario = _mapper.Map<Usuario>(createUsuario);
            await _repository.InsertUsuario(usuario);
        }
        catch (Exception ex)
        {
            return BadRequest(new { data = ex.Message });
        }

        return Ok();
    }

    /// <summary>
    /// Realiza login no sistema
    /// </summary>
    /// <param name="loginUsuario"></param>
    /// <returns></returns>
    /// <response code="201">Usuario cadastrado com sucesos</response>
    /// <response code="400">Falha ao cadastrar usuario</response>
    /// <response code="404">Usuario não cadastrado no sistema</response>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUsuarioDTO loginUsuario)
    {
        try
        {
            Usuario usuario = _mapper.Map<Usuario>(loginUsuario);
            await _repository.LoginUsuario(usuario);
        }
        catch (Exception ex)
        {
            return BadRequest(new { data = ex.Message });
        }

        return Ok();
    }

    /// <summary>
    /// Valida existencia de usuario para redefinir senha
    /// </summary>
    /// <returns></returns>
    /// <response code="201">Usuario existe no sistema</response>
    /// <response code="400">Falha ao buscar usuario</response>
    /// <response code="404">Usuario não localizado</response>
    [HttpGet("valida_usuario/{nome_usuario}")]
    public IActionResult ValidaUsuario(string nome_usuario)
    {
        try
        {

        }
        catch (Exception ex)
        {
            return BadRequest(new { data = ex.Message });
        }

        return Ok();
    }

    /// <summary>
    /// Realiza Updade de senha do Usuario
    /// </summary>
    /// <param name="resetSenhaUsuario"></param>
    /// <returns></returns>
    /// <response code="201">Senha atualizada com sucesso</response>
    /// <response code="400">Falha ao atualizar senha</response>
    [HttpPut("reset_senha")]
    public IActionResult ResetSenha([FromBody] ResetSenhaUsuarioDTO resetSenhaUsuario) 
    {
        try
        {

        }
        catch (Exception ex)
        {
            return BadRequest(new { data = ex.Message });
        }

        return Ok();
    }
}
