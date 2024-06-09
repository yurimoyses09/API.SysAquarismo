using Api.SysAquarismo.Domain.Dtos.UsuarioDTO;
using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models;
using Api.SysAquarismo.Domain.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.SysAquarismo.Application.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/v1/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _repository;
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(IMapper mapper, IUsuarioRepository repository, ILogger<UsuarioController> logger)
    {
        _mapper = mapper;
        _repository = repository;
        _logger = logger;
    }

    /// <summary>
    /// Cadastra usuario no sistema
    /// </summary>
    /// <param name="createUsuario">Dados usados para realizar cadastro no sistema</param>
    /// <returns></returns>
    /// <response code="201">Usuario cadastrado com sucesos</response>
    /// <response code="400">Falha ao cadastrar usuario</response>
    [HttpPost("cadastra")]
    public async Task<IActionResult> Cadastra([FromBody] CreateUsuarioDTO createUsuario)
    {
        try
        {
            _logger.LogInformation("Dados recebidos no request!");

            Usuario usuario = _mapper.Map<Usuario>(createUsuario);

            _logger.LogInformation("Buscando usuario com o mesmo login!");
            List<dynamic> validacao = _repository.BuscaMesmoLogin(usuario).Result;
            if (validacao.Any()) 
            {
                _logger.LogWarning("O usuario informado ja possui conta no sistema!");
                return Ok(new Response<CreateUsuarioDTO>(createUsuario, $"Nome de login {createUsuario.Ds_Nome_Usuario_Login} já existe!"));
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
    public async Task<IActionResult> Login([FromBody] LoginUsuarioDTO loginUsuario)
    {
        try
        {
            _logger.LogInformation("Dados recebidos no request!");

            Usuario usuario = _mapper.Map<Usuario>(loginUsuario);

            _logger.LogInformation("Efetuando login no sistema!");
            List<dynamic> usuarioValido = await _repository.LoginUsuario(usuario);

            if (usuarioValido != null && usuarioValido.Count > 0) 
            {
                _logger.LogInformation("Login efetuado com sucesso!");
                return Ok(new Response<LoginUsuarioDTO?>(loginUsuario, "Login efetuado com sucesso!"));
            }
            else 
            {
                _logger.LogWarning("Usuario não cadastrado no sistema!");
                return BadRequest(new Response<LoginUsuarioDTO?>(loginUsuario, "Usuario não cadastrado no sistema!"));
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
    /// <param name="nome_usuario"></param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Dados encontrados com sucesso</response>
    /// <response code="400">Falha buscar dados</response>
    [HttpGet("{nome_usuario}")]
    public async Task<IActionResult> BuscaUsuarioPorNomeLogin(string nome_usuario)
    {
        try
        {
            _logger.LogInformation("Dados recebidos no request!");

            _logger.LogInformation("Buscando dados no usuario no sistema!");
            Usuario result = await _repository.BuscaDadosUsuario(nome_usuario);

            ReadUsuarioDTO dados = _mapper.Map<ReadUsuarioDTO>(result);

            _logger.LogInformation("Dados recuperados com sucesso!");

            return BadRequest(new Response<ReadUsuarioDTO?>(dados, "Dados recuperados com sucesso!"));
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
