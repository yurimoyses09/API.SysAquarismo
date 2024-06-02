using Api.SysAquarismo.Domain.Models;

namespace Api.SysAquarismo.Domain.Interfaces;

public interface IPeixeRepository
{
    Task<int> InsertPeixe(Peixe peixe);
    Task<int> DeletePeixe(Peixe peixe);
    Task GetPeixe();
    Task<int> UpdatePeixe(Peixe peixe);
    Task<IEnumerable<Peixe>> GetPeixePorId(int id);
}
