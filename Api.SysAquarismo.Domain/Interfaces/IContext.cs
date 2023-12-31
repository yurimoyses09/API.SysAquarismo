﻿using System.Collections;

namespace Api.SysAquarismo.Domain.Interfaces;

public interface IContext
{
    Task<IEnumerable> SelectAsync(string query, object param);
    Task<IEnumerable<Object>> SelectAsync<Object>(string query, object param);
    Task<int> InsertAsync(string query, object parameters);
    Task<int> DeleteAsync(string query);
    Task<int> UpdateAsync(string query);
    Task CloseConnection();
}
