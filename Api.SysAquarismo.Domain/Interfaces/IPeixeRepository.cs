using Api.SysAquarismo.Domain.Models;

namespace Api.SysAquarismo.Domain.Interfaces;

public interface IPeixeRepository
{
    Task<int> InsertPeixe(Peixe peixe);
    Task DeletePeixe(Peixe peixe);
    Task GetPeixe();
    Task UpdatePeixe(Peixe peixe);
    Task<dynamic> GetPeixePorId(int id);
}
