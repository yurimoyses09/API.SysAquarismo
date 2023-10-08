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

    public Task DeletePeixe(Peixe peixe)
    {
        throw new NotImplementedException();
    }

    public Task GetPeixe()
    {
        throw new NotImplementedException();
    }

    public async Task<dynamic> GetPeixePorId(int id)
    {
        try
        {
            string query = PeixeDQ.BuscaDadosPeixe(id);

            IEnumerable<Peixe> dados = _context.SelectAsync<Peixe>(query).Result;

            return dados;
        }
        catch (Exception)
        {
            throw;
        }finally
        {
            await _context.CloseConnection();
        }
    }

    public async Task<int> InsertPeixe(Peixe peixe)
    {
        try
        {
            string query = PeixeDQ.QueryCriaPeixe(peixe);

            return _context.InsertAsync(query).Result;
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

    public Task UpdatePeixe(Peixe peixe)
    {
        throw new NotImplementedException();
    }
}
