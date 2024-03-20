namespace LinkedChain.BuildingBlocks.Infrastructure.DomainEvents;

public interface IDomainNotificationsMapper
{
    string? GetName(Type type);

    Type? GetType(string name);
}