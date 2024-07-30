using Dapper;
using LinkedChain.Modules.Recruitment.Application.Offers;
using LinkedChain.Modules.Recruitment.Infrastructure.Configuration.Outbox;
using MediatR;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;

namespace LinkedChain.Modules.Recruitment.IntegrationTests.SeedWork;

public class OutboxMessagesHelper
{
    public static async Task<List<OutboxMessageDto>> GetOutboxMessages(IDbConnection connection)
    {
        const string sql = $"""
                                SELECT [OutboxMessage].[Id] as [{nameof(OutboxMessageDto.Id)}], 
                                       [OutboxMessage].[Type] as [{nameof(OutboxMessageDto.Type)}],
                                       [OutboxMessage].[Data] as [{nameof(OutboxMessageDto.Data)}] 
                                FROM [recruitment].[OutboxMessages] AS [OutboxMessage] 
                                ORDER BY [OutboxMessage].[OccurredOn]
                                """;

        var messages = await connection.QueryAsync<OutboxMessageDto>(sql);
        return messages.AsList();
    }

    public static T Deserialize<T>(OutboxMessageDto message)
        where T : class, INotification
    {
        Type type = Assembly.GetAssembly(typeof(OfferAcceptedNotification)).GetType(message.Type);
        return JsonConvert.DeserializeObject(message.Data, type) as T;
    }
}