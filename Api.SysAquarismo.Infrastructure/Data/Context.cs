using Api.SysAquarismo.Domain.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data;

namespace Api.SysAquarismo.Infrastructure.Data;

public class Context : IContext
{
    private readonly SqlConnection _connection;
    private readonly string connectionString = Environment.GetEnvironmentVariable("AMBIENTE_DB_DEV", EnvironmentVariableTarget.User);

    public Context()
    {
        try
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("A string de conexão com o banco não existe nas variaveis de ambiente da conta");

            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }
        catch (SqlException)
        {
            throw;
        }
        catch (Exception)
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
    /// Metodo responsavel por realizar consultar de um para muitos
    /// </summary>
    /// <typeparam name="TParent">Representa a entidade principal</typeparam>
    /// <typeparam name="TChild">Classe que é a lista dentro da classe de retorno</typeparam>
    /// <typeparam name="TKey">Representa para identificar a relação entre as entidades</typeparam>
    /// <param name="query">Query que sera executada no servidor de banco de dados</param>
    /// <param name="parentKeySelector"></param>
    /// <param name="childKeySelector"></param>
    /// <param name="addChildAction"></param>
    /// <param name="parameters">Representa os parameters da query</param>
    /// <param name="spliton">Representa a chave de separação entre as tabelas</param>
    /// <returns></returns>
    public async Task<IEnumerable<TParent>> SelectManyAsync<TParent, TChild, TKey>(string query, Func<TParent, TKey> parentKeySelector, Func<TChild, TKey> childKeySelector, Action<TParent, TChild> addChildAction, object parameters, string spliton)
    {
        var parentMap = new Dictionary<TKey, TParent>();

        var result = await _connection.QueryAsync<TParent, TChild, TParent>(
            query,
            (parent, child) =>
            {
                var parentKey = parentKeySelector(parent);
                if (!parentMap.TryGetValue(parentKey, out var parentEntry))
                {
                    parentEntry = parent;
                    parentMap.Add(parentKey, parentEntry);
                }
                addChildAction(parentEntry, child);

                return parentEntry;
            },
            param: parameters,
            splitOn: spliton
        );

        return parentMap.Values;
    }

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
    /// Realiza execução de uma procedure que nao envolve retorno de objetos
    /// </summary>
    /// <param name="query"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public async Task<int> ExecuteProcedureAsync(string query, object parameters)
        => await _connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

    /// <summary>
    /// Realiza execução de uma procedure que retorna dados 
    /// </summary>
    /// <typeparam name="Object"></typeparam>
    /// <param name="query"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Object>> ReadProcedureAsync<Object>(string query, object parameters)
        => await _connection.QueryAsync<Object>(query, parameters, commandType: CommandType.StoredProcedure);

    /// <summary>
    /// Fecha conexão com o banco de dados
    /// </summary>
    /// <returns></returns>
    public async Task CloseConnection()
    {
        try
        {
            if (_connection.State == ConnectionState.Open)
                await _connection.CloseAsync();
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            _connection.Dispose();
        }
    }
}