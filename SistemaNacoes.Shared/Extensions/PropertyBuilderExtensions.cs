using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SistemaNacoes.Shared.Extensions;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<TEnum> HasEnumConversion<TEnum>(this PropertyBuilder<TEnum> builder) where TEnum : struct, Enum
    {
        var converter = new ValueConverter<TEnum, string>(
            v => v.ToString(), 
            v => (TEnum)Enum.Parse(typeof(TEnum), v)
        );

        return builder.HasConversion(converter);
    }
    
    public static PropertyBuilder<TEnum?> HasEnumConversion<TEnum>(this PropertyBuilder<TEnum?> builder)
        where TEnum : struct, Enum
    {
        var converter = new ValueConverter<TEnum?, string?>(
            v => v.HasValue ? v.Value.ToString() : null,
            v => string.IsNullOrEmpty(v) ? (TEnum?)null : (TEnum)Enum.Parse(typeof(TEnum), v)
        );

        return builder.HasConversion(converter);
    }
}