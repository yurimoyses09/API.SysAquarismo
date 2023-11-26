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
        catch (SqlException)
        {
            throw;
        }
        catch(Exception) 
        {
            throw;
        }
    }

    /// <summary>
    /// Realiza consultas de select no banco de dados
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Object>> SelectAsync(string query) => await _connection.QueryAsync<Object>(query);

    /// <summary>
    /// Realiza consultas de select no banco de dados
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Object>> SelectAsync<Object>(string query, object parameters) => await _connection.QueryAsync<Object>(query, parameters);

    /// <summary>
    /// Realiza insert de dados no banco de dados
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<int> InsertAsync(string query, object parameters) => await _connection.ExecuteAsync(query, parameters);

    /// <summary>
    /// Realiza o delete de dados do banco de dados
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<int> DeleteAsync(string query) => await _connection.ExecuteAsync(query);
    
    /// <summary>
    /// Realiza o update de dados no banco de dados
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<int> UpdateAsync(string query) => await _connection.ExecuteAsync(query);

    /// <summary>
    /// Fecha conexão com o bando de dados
    /// </summary>
    /// <returns></returns>
    public async Task CloseConnection()
    {
        try
        {
            if (_connection.State == System.Data.ConnectionState.Closed) await _connection.CloseAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
