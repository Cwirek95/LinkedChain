using System.Data;

namespace LinkedChain.BuildingBlocks.Application.DataAccess;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();

    IDbConnection CreateNewConnection();

    string GetConnectionString();
}