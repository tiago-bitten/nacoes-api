using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SistemaNacoes.Shared.Extensions;

public static class ModelBuilderExtensions
{
    public static void AplicarNomenclaturaNacoes(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(ConverterParaSnakeCase(Pluralizar(entity.GetTableName())));

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(ConverterParaSnakeCase(property.Name));
            }

            var primaryKey = entity.FindPrimaryKey();
            primaryKey?.SetName($"pk_{ConverterParaSnakeCase(entity.GetTableName())}");

            foreach (var foreignKey in entity.GetForeignKeys())
            {
                foreignKey.SetConstraintName($"fk_{ConverterParaSnakeCase(entity.GetTableName())}_{ConverterParaSnakeCase(foreignKey.PrincipalEntityType.GetTableName())}");
            }

            foreach (var index in entity.GetIndexes())
            {
                var columnNames = string.Join("_", index.Properties.Select(p => ConverterParaSnakeCase(p.Name)));
                index.SetDatabaseName($"ix_{ConverterParaSnakeCase(entity.GetTableName())}_{columnNames}");
            }
        }
    }

    private static string? ConverterParaSnakeCase(string? input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var regex = new Regex("([a-z0-9])([A-Z])");
        return regex.Replace(input, "$1_$2").ToLower(CultureInfo.InvariantCulture);
    }

    private static string? Pluralizar(string? input)
    {
        if (input != null && input.EndsWith("s")) return input;
        return input + "s";
    }
}