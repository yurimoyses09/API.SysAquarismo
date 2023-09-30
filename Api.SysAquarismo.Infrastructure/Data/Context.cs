using Api.SysAquarismo.Domain.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Api.SysAquarismo.Infrastructure.Data;

public class Context : IContext
{
    public readonly SqlConnection _connection;
    private readonly string connectionString = Environment.GetEnvironmentVariable("AMBIENTE_DB_DEV", EnvironmentVariableTarget.User);

    public Context(SqlConnection? connection = null)
    {
        try
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            _connection = connection;
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

    public async Task<IEnumerable<Object>> SelectAsync(string query) => await _connection.QueryAsync<Object>(query);

    public async Task<int> InsertAsync(string query) => await _connection.ExecuteAsync(query);

    public async Task<int> DeleteAsync(string query) => await _connection.ExecuteAsync(query);
    
    public async Task<int> UpdateAsync(string query) => await _connection.ExecuteAsync(query);

    public async Task CloseConnection()
    {
        try
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
                await _connection.CloseAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Object>> SelectAsync<Object>(string query) => await _connection.QueryAsync<Object>(query);
}
