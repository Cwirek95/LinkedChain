using System.Collections.Concurrent;
using LinkedChain.BuildingBlocks.Domain;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LinkedChain.BuildingBlocks.Infrastructure.Converters;

public class StronglyTypedIdValueConverterSelector : ValueConverterSelector
{
    private readonly ConcurrentDictionary<(Type ModelClrType, Type ProviderClrType), ValueConverterInfo> _converters
        = new ConcurrentDictionary<(Type ModelClrType, Type ProviderClrType), ValueConverterInfo>();

    public StronglyTypedIdValueConverterSelector(ValueConverterSelectorDependencies dependencies)
        : base(dependencies)
    {
    }

    public override IEnumerable<ValueConverterInfo> Select(Type modelClrType, Type providerClrType = null)
    {
        var baseConverters = base.Select(modelClrType, providerClrType);
        foreach (var converter in baseConverters)
        {
            yield return converter;
        }

        var underlyingModelType = UnwrapNullableType(modelClrType);
        var underlyingProviderType = UnwrapNullableType(providerClrType);

        if (underlyingProviderType is null || underlyingProviderType == typeof(Guid))
        {
            var isTypedIdValue = typeof(TypedIdValueBase).IsAssignableFrom(underlyingModelType);
            if (isTypedIdValue)
            {
                var converterType = typeof(TypedIdValueConverter<>).MakeGenericType(underlyingModelType);

                yield return _converters.GetOrAdd((underlyingModelType, typeof(Guid)), _ =>
                {
                    return new ValueConverterInfo(
                        modelClrType: modelClrType,
                        providerClrType: typeof(Guid),
                        factory: valueConverterInfo => (ValueConverter)Activator.CreateInstance(converterType, valueConverterInfo.MappingHints));
                });
            }
        }
    }

    private static Type? UnwrapNullableType(Type? type)
        => type is null ? null : Nullable.GetUnderlyingType(type) ?? type;
}