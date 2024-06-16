using Api.SysAquarismo.Domain.Dtos.PeixeDTO;
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
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/peixe")]
public class PeixeController(IMapper mapper, IPeixeRepository repository, ILogger<PeixeController> logger) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly IPeixeRepository _repository = repository;
    private readonly ILogger<PeixeController> _logger = logger;

    /// <summary>
    /// Obtem dados do peixe pelo id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Sucesso ao buscar dados</response>
    /// <response code="400">Falha ao buscar dados do peixe</response>
    /// <response code="404">Peixe nao cadastrado</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Response<IEnumerable<ReadPeixeDTO>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetPorId([FromRoute] int id)
    {
        try
        {
            _logger.LogInformation("Dados recebidos no request!");

            _logger.LogInformation($"Buscando dados do peixe de id {id}!");
            var result = await _repository.GetPeixePorId(id);

            var dados = _mapper.Map<IEnumerable<ReadPeixeDTO>>(result);

            if (dados == null || !dados.Any())
            {
                _logger.LogWarning("Peixe nao existe no sistema!");
                return NotFound();
            }

            _logger.LogInformation("Peixe encontrado com sucesso!");
            return Ok(new Response<IEnumerable<ReadPeixeDTO>>(dados));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(new Response<IEnumerable<ReadPeixeDTO>?>(null, message: ex.Message));
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
    [ProducesResponseType(typeof(Response<CreatePeixeDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Cadastra([FromBody] CreatePeixeDTO createPeixe)
    {
        try
        {
            _logger.LogInformation("Dados recebidos no request!");
            Peixe peixe = _mapper.Map<Peixe>(createPeixe);

            _logger.LogInformation("Incluindo peixe nas bases de dados!");
            await _repository.InsertPeixe(peixe);

            _logger.LogInformation("Registro criado com sucesso");
            return Ok(new Response<CreatePeixeDTO>(createPeixe, "Registro criado com sucesso"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(new Response<CreatePeixeDTO>(null, ex.Message));
        }
    }

    /// <summary>
    /// Deleta peixe
    /// </summary>
    /// <param name="deletePeixeDTO"></param>
    /// <returns></returns>
    /// <response code="200">Sucesso ao deletar dados</response>
    /// <response code="400">Falha ao deletar dados do peixe</response>
    /// <response code="404">Peixe nao cadastrado</response>
    [HttpDelete("deleta")]
    [ProducesResponseType(typeof(Response<DeletePeixeDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeletaPorId([FromBody] DeletePeixeDTO deletePeixeDTO)
    {
        try
        {
            _logger.LogInformation("Dados recebidos no request!");
            Peixe peixe = _mapper.Map<Peixe>(deletePeixeDTO);

            _logger.LogInformation("Deletando peixe nas bases de dados!");
            await _repository.DeletePeixe(peixe);

            _logger.LogInformation("Registro Deletado com sucesso");
            return Ok(new Response<DeletePeixeDTO>(deletePeixeDTO, "Registro deletado com sucesso"));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<DeletePeixeDTO>(deletePeixeDTO, ex.Message));
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
    [ProducesResponseType(typeof(Response<DeletePeixeDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AtualizaPorId([FromBody] UpdatePeixeDTO updatePeixeDTO)
    {
        try
        {
            _logger.LogInformation("Dados recebidos no request!");
            Peixe peixe = _mapper.Map<Peixe>(updatePeixeDTO);

            _logger.LogInformation("Atualizando peixe nas bases de dados!");
            await _repository.UpdatePeixe(peixe);

            _logger.LogInformation("Registro atualizado com sucesso");
            return Ok(new Response<UpdatePeixeDTO>(updatePeixeDTO, "Registro criado com sucesso"));
        }
        catch (Exception ex)
        {
            return BadRequest(new Response<CreatePeixeDTO?>(null, ex.Message));
        }
    }
}
