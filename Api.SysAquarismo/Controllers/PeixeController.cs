using Api.SysAquarismo.Domain.Dtos.PeixeDTO;
using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.SysAquarismo.Application.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/v1/peixe")]
public class PeixeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPeixeRepository _repository;
    private readonly ILogger _logger;
    public PeixeController(IMapper mapper, IPeixeRepository repository, ILogger logger)
    {
        _mapper = mapper;
        _repository = repository;
        _logger = logger;
    }

    /// <summary>
    /// Obtem dados do peixe pelo id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Sucesso ao buscar dados</response>
    /// <response code="400">Falha ao buscar dados do peixe</response>
    /// <response code="404">Peixe nao cadastrado</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPorId([FromRoute]int id)
    {
        try
        {
            _logger.LogInformation("Dados recebidos no request!");

            _logger.LogInformation($"Buscando dados do peixe de id {id}!");
            var result = await _repository.GetPeixePorId(id);

            var dados = _mapper.Map<IEnumerable<ReadPeixeDTO>>(result);

            if (dados == null)
            {
                _logger.LogWarning("Peixe nao existe no sistema!");
                return NotFound();
            }

            _logger.LogInformation("Peixe encontrado com sucesso!");
            return Ok(new { data = dados });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
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
    public async Task<IActionResult> Cadastra([FromBody] CreatePeixeDTO createPeixe)
    {
        try
        {
            _logger.LogInformation("Dados recebidos no request!");
            Peixe peixe = _mapper.Map<Peixe>(createPeixe);

            _logger.LogInformation("Incluindo peixe nas bases de dados!");
            await _repository.InsertPeixe(peixe);

            _logger.LogInformation("Registro criado com sucesso");
            return Ok(new { data = createPeixe });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(new { data = ex.Message });
        }
    }

    #region [ Endpoints nao implementados ainda ]

    /// <summary>
    /// Deleta peixe a partir do nome
    /// </summary>
    /// <param name="nome_peixe"></param>
    /// <returns></returns>
    /// <response code="200">Sucesso ao deletar dados</response>
    /// <response code="400">Falha ao deletar dados do peixe</response>
    /// <response code="404">Peixe nao cadastrado</response>
    [HttpDelete("deleta/{nome_peixe}")]
    public async Task<IActionResult> DeletaPorId(string nome_peixe)
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
    [HttpPut("atualiza")]
    public async Task<IActionResult> AtualizaPorId([FromBody] UpdatePeixeDTO updatePeixeDTO)
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

    #endregion
}
