using System.Collections;

namespace Api.SysAquarismo.Domain.Interfaces;

public interface IContext
{
    Task<IEnumerable> SelectAsync(string query, object parameters);
    Task<IEnumerable<Object>> SelectAsync<Object>(string query, object parameters);
    Task<int> InsertAsync(string query, object parameters);
    Task<int> DeleteAsync(string query, object parameters);
    Task<int> UpdateAsync(string query, object parameters);
    Task CloseConnection();
}
