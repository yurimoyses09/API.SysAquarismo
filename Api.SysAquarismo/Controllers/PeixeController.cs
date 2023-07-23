using Api.SysAquarismo.Domain.Dtos.PeixeDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.SysAquarismo.Application.Controllers;

[Authorize]
[ApiController]
[Produces("application/json")]
[Route("api/v1/peixe")]
public class PeixeController : ControllerBase
{
    readonly ILogger _logger;
    public PeixeController(ILogger logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Obtem dados do peixe pelo nome
    /// </summary>
    /// <param name="nome_peixe"></param>
    /// <returns></returns>
    /// <response code="200">Sucesso ao buscar dados</response>
    /// <response code="400">Falha ao buscar dados do peixe</response>
    /// <response code="404">Peixe nao cadastrado</response>
    [HttpGet("nome_peixe")]
    public IActionResult ObtemPeixePorNome(string nome_peixe)
    {
        try
        {

        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex, ex.Message.ToString());
            return BadRequest(new { data = ex.Message });
        }

        return Ok(new { data = "" });
    }

    /// <summary>
    /// Cadastra peixe
    /// </summary>
    /// <param name="createPeixe"></param>
    /// <returns></returns>
    /// <response code="200">Sucesso ao cadastrar peixe</response>
    /// <response code="400">Falha ao cadastrar dados do peixe</response>
    [HttpPost("cadastra")]
    public IActionResult CadastraPeixe([FromBody] CreatePeixeDTO createPeixe)
    {
        try
        {

        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex, ex.Message.ToString());
            return BadRequest(new { data = ex.Message });
        }

        return Ok(new { data = "" });
    }

    /// <summary>
    /// Deleta peixe a partir do nome
    /// </summary>
    /// <param name="nome_peixe"></param>
    /// <returns></returns>
    /// <response code="200">Sucesso ao deletar dados</response>
    /// <response code="400">Falha ao deletar dados do peixe</response>
    /// <response code="404">Peixe nao cadastrado</response>
    [HttpDelete("deleta/{nome_peixe}")]
    public IActionResult DeletaPeixePorNome(string nome_peixe)
    {
        try
        {

        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex, ex.Message.ToString());
            return BadRequest(new { data = ex.Message });
        }

        return Ok(new { data = "" });
    }

    /// <summary>
    /// Atualiza dados do peixe
    /// </summary>
    /// <param name="updatePeixeDTO"></param>
    /// <returns></returns>
    /// <response code="200">Sucesso ao atualizar dados</response>
    /// <response code="400">Falha ao buscar dados do peixe</response>
    /// <response code="404">Peixe nao cadastrado</response>
    [HttpPut("atualiza_peixe")]
    public IActionResult AtualizaPeixe([FromBody] UpdatePeixeDTO updatePeixeDTO)
    {
        try
        {

        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex, ex.Message.ToString());
            return BadRequest(new { data = ex.Message });
        }

        return Ok(new { data = "" });
    }
}
