using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models.Peixe;
using Api.SysAquarismo.Infrastructure.Data.Context;

namespace Api.SysAquarismo.Infrastructure.Data.Repository;

public class PeixeRepository : IPeixeRepository
{

    private readonly PeixeContext _context;
    public PeixeRepository(PeixeContext context = null)
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

    public Task InsertPeixe(Peixe peixe)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePeixe(Peixe peixe)
    {
        throw new NotImplementedException();
    }
}
