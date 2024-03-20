using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LinkedChain.BuildingBlocks.Infrastructure.Serializations;

public class AllPropertiesContractResolver : DefaultContractResolver
{
    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        var properties = type.GetProperties(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance)
            .Select(p => CreateProperty(p, memberSerialization))
            .ToList();

        properties.ForEach(p =>
        {
            p.Writable = true;
            p.Readable = true;
        });

        return properties;
    }
}