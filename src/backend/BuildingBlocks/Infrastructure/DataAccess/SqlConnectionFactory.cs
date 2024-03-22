using System.Data;
using System.Data.SqlClient;
using LinkedChain.BuildingBlocks.Application.DataAccess;

namespace LinkedChain.BuildingBlocks.Infrastructure.DataAccess;

public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
{
    private readonly string _connectionString;
    private IDbConnection? _connection;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection GetOpenConnection()
    {
        if (_connection?.State == ConnectionState.Open)
            return _connection;
        
        _connection = new SqlConnection(_connectionString);
        _connection.Open();

        return _connection;
    }

    public IDbConnection CreateNewConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();

        return connection;
    }

    public string GetConnectionString()
    {
        return _connectionString;
    }

    public void Dispose()
    {
        if (_connection is { State: ConnectionState.Open })
        {
            _connection.Dispose();
        }
    }
}