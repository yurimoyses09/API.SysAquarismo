using Api.SysAquarismo.Domain.Interfaces;
using Api.SysAquarismo.Domain.Models.Peixe;

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

    public Task InsertPeixe(Peixe peixe)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePeixe(Peixe peixe)
    {
        throw new NotImplementedException();
    }
}
