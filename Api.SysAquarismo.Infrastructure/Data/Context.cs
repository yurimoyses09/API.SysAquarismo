using Api.SysAquarismo.Domain.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections;

namespace Api.SysAquarismo.Infrastructure.Data;

public class Context : IContext
{
    private readonly SqlConnection _connection;
    private readonly string connectionString = Environment.GetEnvironmentVariable("AMBIENTE_DB_DEV", EnvironmentVariableTarget.User);

    public Context()
    {
        try
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
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
    public async Task<IEnumerable> SelectAsync(string query, object parameters) 
        => await _connection.QueryAsync(query, parameters);

    /// <summary>
    /// Realiza consultas de select no banco de dados
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Object>> SelectAsync<Object>(string query, object parameters)
        => await _connection.QueryAsync<Object>(query, parameters);

    /// <summary>
    /// Realiza insert de dados no banco de dados
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<int> InsertAsync(string query, object parameters) 
        => await _connection.ExecuteAsync(query, parameters);

    /// <summary>
    /// Realiza o delete de dados do banco de dados
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<int> DeleteAsync(string query, object parameters) 
        => await _connection.ExecuteAsync(query, parameters);
    
    /// <summary>
    /// Realiza o update de dados no banco de dados
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<int> UpdateAsync(string query, object parameters) 
        => await _connection.ExecuteAsync(query, parameters);

    /// <summary>
    /// Fecha conexão com o banco de dados
    /// </summary>
    /// <returns></returns>
    public async Task CloseConnection()
    {
        try
        {
            if (_connection.State == System.Data.ConnectionState.Open) 
                await _connection.CloseAsync();
        }
        catch (Exception)
        {
            throw;
        }finally 
        {
            _connection.Dispose();
        }
    }
}
