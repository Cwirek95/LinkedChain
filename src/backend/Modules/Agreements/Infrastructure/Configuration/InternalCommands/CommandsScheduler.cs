using Dapper;
using LinkedChain.BuildingBlocks.Application.DataAccess;
using LinkedChain.BuildingBlocks.Infrastructure.Serializations;
using LinkedChain.Modules.Agreements.Application.Configurations.Commands;
using LinkedChain.Modules.Agreements.Application.Contracts;
using Newtonsoft.Json;

namespace LinkedChain.Modules.Agreements.Infrastructure.Configuration.InternalCommands;

public class CommandsScheduler : ICommandsScheduler
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public CommandsScheduler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task EnqueueAsync(ICommand command)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        const string sqlInsert = "INSERT INTO [agreements].[InternalCommands] ([Id], [EnqueueDate] , [Type], [Data]) VALUES " +
                                 "(@Id, @EnqueueDate, @Type, @Data)";

        await connection.ExecuteAsync(sqlInsert, new
        {
            command.Id,
            EnqueueDate = DateTime.UtcNow,
            Type = command.GetType().FullName,
            Data = JsonConvert.SerializeObject(command, new JsonSerializerSettings
            {
                ContractResolver = new AllPropertiesContractResolver()
            })
        });
    }

    public Task EnqueueAsync<T>(ICommand<T> command)
    {
        throw new NotImplementedException();
    }
}