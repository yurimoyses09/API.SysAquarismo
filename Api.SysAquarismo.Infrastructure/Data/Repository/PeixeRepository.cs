using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models;
using Api.SysAquarismo.Infrastructure.Querys;

namespace Api.SysAquarismo.Infrastructure.Data.Repository;

public class PeixeRepository(IContext context) : IPeixeRepository
{
    private readonly IContext _context = context;

    public async Task<IEnumerable<Peixe>> GetPeixePorId(int id_peixe)
    {
        try
        {
            string query = PeixeQD.BuscaDadosPeixe();
            object parameters = new { id_peixe };

            IEnumerable<Peixe> dados = await _context.ReadProcedureAsync<Peixe>(query, parameters);

            return dados;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await _context.CloseConnection();
        }
    }

    public async Task<int> InsertPeixe(Peixe peixe)
    {
        try
        {
            string query = PeixeQD.QueryCriaPeixe();

            object parameters = new
            {
                peixe.nome_peixe,
                peixe.nome_especie,
                peixe.descricao,
                peixe.sexo,
                peixe.id_saude,
                peixe.peso,
                peixe.tamanho,
                dt_morte = peixe.dt_morte != null ? DateTime.Parse(Convert.ToString(peixe.dt_morte)).ToString("yyyy-MM-dd") : null,
                peixe.ds_doenca,
                dt_aquisicao = peixe.dt_aquisicao != null ? DateTime.Parse(Convert.ToString(peixe.dt_aquisicao)).ToString("yyyy-MM-dd") : null,
                peixe.ds_imagem,
                peixe.id_usuario
            };

            return await _context.InsertAsync(query, parameters);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await _context.CloseConnection();
        }
    }

    public async Task<int> DeletePeixe(Peixe peixe)
    {
        try
        {
            string query = PeixeQD.QueryDeletaPeixe();

            object parameters = new { peixe.id_peixe };

            return await _context.ExecuteProcedureAsync(query, parameters);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await _context.CloseConnection();
        }
    }

    public async Task<int> UpdatePeixe(Peixe peixe)
    {
        try
        {
            string query = PeixeQD.QueryUpdatePeixe();

            object parameters = new
            {
                peixe.nome_peixe,
                peixe.nome_especie,
                peixe.descricao,
                peixe.sexo,
                peixe.id_saude,
                peixe.peso,
                peixe.tamanho,
                dt_morte = peixe.dt_morte != null ? DateTime.Parse(Convert.ToString(peixe.dt_morte)).ToString("yyyy-MM-dd") : null, //DateTime.Parse(Convert.ToString(peixe.Ds_Data_Morte)).ToString("yyyy-MM-dd") ?? null,
                peixe.ds_doenca,
                dt_aquisicao = peixe.dt_aquisicao != null ? DateTime.Parse(Convert.ToString(peixe.dt_aquisicao)).ToString("yyyy-MM-dd") : null,
                peixe.ds_imagem,
                peixe.id_peixe
            };

            return await _context.UpdateAsync(query, parameters);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await _context.CloseConnection();
        }
    }
}
