using LinkedChain.BuildingBlocks.Infrastructure.Common;

namespace LinkedChain.BuildingBlocks.Infrastructure.InternalCommands;

public class InternalCommandsMapper : IInternalCommandsMapper
{
    private readonly BiDictionary<string, Type> _internalCommandsMap;

    public InternalCommandsMapper(BiDictionary<string, Type> internalCommandsMap)
    {
        _internalCommandsMap = internalCommandsMap;
    }

    public string? GetName(Type type)
        => _internalCommandsMap.TryGetBySecond(type, out var name) ? name : null;

    public Type? GetType(string name)
        => _internalCommandsMap.TryGetByFirst(name, out var type) ? type : null;
}