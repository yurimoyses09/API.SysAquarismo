using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models;
using Api.SysAquarismo.Domain.Models.Usuario;
using Api.SysAquarismo.Infrastructure.Querys.PeixeQD;
using Api.SysAquarismo.Infrastructure.Querys.UsuarioQD;

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

    public async Task<int> InsertPeixe(Peixe peixe)
    {
        try
        {
            string query = PeixeDQ.QueryCriaPeixe(peixe);

            return _context.InsertAsync(query).Result;
        }
        catch (Exception ex)
        {
            throw ex;
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
