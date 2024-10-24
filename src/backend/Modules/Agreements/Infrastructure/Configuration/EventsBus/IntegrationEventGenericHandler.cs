using Dapper;
using LinkedChain.BuildingBlocks.Application.DataAccess;
using LinkedChain.BuildingBlocks.Infrastructure.EventBus;
using LinkedChain.BuildingBlocks.Infrastructure.Serializations;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace LinkedChain.Modules.Agreements.Infrastructure.Configuration.EventsBus;

internal class IntegrationEventGenericHandler<T> : IIntegrationEventHandler<T>
    where T : IntegrationEvent
{
    public async Task Handle(T @event)
    {
        using (var scope = AgreementsCompositionRoot.BeginLifetimeScope())
        {
            var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
            using (var connection = sqlConnectionFactory.GetOpenConnection())
            {
                string type = @event.GetType().FullName;
                var data = JsonConvert.SerializeObject(@event, new JsonSerializerSettings
                {
                    ContractResolver = new AllPropertiesContractResolver()
                });

                var sql = "INSERT INTO [agreements].[InboxMessages] (Id, OccurredOn, Type, Data) " +
                          "VALUES (@Id, @OccurredOn, @Type, @Data)";

                await connection.ExecuteScalarAsync(sql, new
                {
                    @event.Id,
                    @event.OccurredOn,
                    type,
                    data
                });
            }
        }
    }
}