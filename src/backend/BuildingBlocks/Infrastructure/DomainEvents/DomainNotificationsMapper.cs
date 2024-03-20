using LinkedChain.BuildingBlocks.Infrastructure.Common;

namespace LinkedChain.BuildingBlocks.Infrastructure.DomainEvents;

public class DomainNotificationsMapper : IDomainNotificationsMapper
{
    private readonly BiDictionary<string, Type> _domainNotificationsMap;

    public DomainNotificationsMapper(BiDictionary<string, Type> domainNotificationsMap)
    {
        _domainNotificationsMap = domainNotificationsMap;
    }

    public string? GetName(Type type)
        => _domainNotificationsMap.TryGetBySecond(type, out var name) ? name : null;

    public Type? GetType(string name)
        => _domainNotificationsMap.TryGetByFirst(name, out var type) ? type : null;
}