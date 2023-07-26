namespace Api.SysAquarismo.Domain.Interfaces;

public interface IContext
{
    Task<IEnumerable<dynamic>> SelectAsync(string query);
    Task<int> InsertAsync(string query);
    Task<int> DeleteAsync(string query);
    Task<int> UpdateAsync(string query);
    Task CloseConnection();
}
