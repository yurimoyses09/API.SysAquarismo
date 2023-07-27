using Api.SysAquarismo.Domain.Dtos.PeixeDTO;
using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models.Peixe;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.SysAquarismo.Application.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/v1/peixe")]
public class PeixeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPeixeRepository _repository;
    public PeixeController(IMapper mapper, IPeixeRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
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
    public async Task<IActionResult> ObtemPeixePorNome(string nome_peixe)
    {
        try
        {
            return Ok(new { data = "" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { data = ex.Message });
        }
    }

    /// <summary>
    /// Cadastra peixe
    /// </summary>
    /// <param name="createPeixe"></param>
    /// <returns></returns>
    /// <response code="200">Sucesso ao cadastrar peixe</response>
    /// <response code="400">Falha ao cadastrar dados do peixe</response>
    [HttpPost("cadastra")]
    public async Task<IActionResult> CadastraPeixe([FromBody] CreatePeixeDTO createPeixe)
    {
        try
        {
            Peixe peixe = _mapper.Map<Peixe>(createPeixe);
            await _repository.InsertPeixe(peixe);

            return Ok(new { data = createPeixe });
        }
        catch (Exception ex)
        {
            return BadRequest(new { data = ex.Message });
        }
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
    public async Task<IActionResult> DeletaPeixePorNome(string nome_peixe)
    {
        try
        {
            return Ok(new { data = "" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { data = ex.Message });
        }
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
    public async Task<IActionResult> AtualizaPeixe([FromBody] UpdatePeixeDTO updatePeixeDTO)
    {
        try
        {
            return Ok(new { data = "" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { data = ex.Message });
        }
    }
}
