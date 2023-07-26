using Api.SysAquarismo.Domain.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Api.SysAquarismo.Infrastructure.Data;

public class Context : IContext
{
    private SqlConnection _connection;

    public Context(SqlConnection connection = null)
    {
        try
        {
            string connectionString = "";
            using (connection = new SqlConnection(connectionString))
            {
                connection.OpenAsync();
            }

            _connection = connection;
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

    public async Task<IEnumerable<dynamic>> SelectAsync(string query)
    {
        return await _connection.QueryAsync<dynamic>(query);
    }

    public async Task<int> InsertAsync(string query)
    {
        return await _connection.ExecuteAsync(query);
    }

    public async Task<int> DeleteAsync(string query)
    {
        return await _connection.ExecuteAsync(query);
    }

    public async Task<int> UpdateAsync(string query)
    {
        return await _connection.ExecuteAsync(query);
    }
}
