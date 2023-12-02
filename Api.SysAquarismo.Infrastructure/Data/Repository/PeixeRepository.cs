using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models;
using Api.SysAquarismo.Infrastructure.Querys;

namespace Api.SysAquarismo.Infrastructure.Data.Repository;

public class PeixeRepository : IPeixeRepository
{
    private readonly IContext _context;
    public PeixeRepository(IContext context)
    {
        _context = context;
    }

    public async Task<dynamic> GetPeixePorId(int id_peixe)
    {
        try
        {
            string query = PeixeDQ.BuscaDadosPeixe();
            object parameters = new { id_peixe };

            IEnumerable<Peixe> dados = _context.SelectAsync<Peixe>(query, parameters).Result;

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
            string query = PeixeDQ.QueryCriaPeixe();

            object parameters = new
            {
                nome = peixe.Ds_Nome_Peixe,
                especie = peixe.Ds_Nome_Especie,
                descrisao = peixe.Ds_Descricao,
                sexo = (int)peixe.Id_Sexo,
                status_saude = (int)peixe.Id_Status_Saude,
                peso = peixe.Vl_Peso,
                tamanho = peixe.Vl_Tamanho,
                data_morte = DateTime.Parse(Convert.ToString(peixe.Ds_Data_Morte)).ToString("yyyy-MM-dd"),
                doenca = peixe.Ds_Doenca,
                data_aquisicao = DateTime.Parse(Convert.ToString(peixe.Ds_Data_Aquisicao)).ToString("yyyy-MM-dd"),
                imagem = peixe.Ds_Imagem,
                id_usuario = peixe.Id_Usuario

            };

            return _context.InsertAsync(query, parameters).Result;
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

    #region [ Não implementado ]
    public Task DeletePeixe(Peixe peixe)
    {
        throw new NotImplementedException();
    }

    public Task GetPeixe()
    {
        throw new NotImplementedException();
    }

    public Task UpdatePeixe(Peixe peixe)
    {
        throw new NotImplementedException();
    }
    #endregion
}
