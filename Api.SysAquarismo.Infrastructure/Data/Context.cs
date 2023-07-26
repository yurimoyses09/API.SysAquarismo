using Api.SysAquarismo.Domain.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Api.SysAquarismo.Infrastructure.Data;

public class Context : IContext
{
    private readonly SqlConnection _connection;

    public Context(SqlConnection? connection = null)
    {
        try
        {
            var connectionString = Environment.GetEnvironmentVariable("AMBIENTE_DB_DEV", EnvironmentVariableTarget.User);
            connection = new SqlConnection(connectionString);
            
            connection.Open();

            _connection = connection;
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

    public async Task<IEnumerable<dynamic>> SelectAsync(string query) => await _connection.QueryAsync<dynamic>(query);

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
}
