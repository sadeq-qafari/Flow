using System.Collections;
using Dapper;
using Meteor.Utils;

namespace Core.Meteor.Dto
{
    public interface IDataGridInDto
    {
        public string? Sort { get; set; }
        public string? Filter { get; set; }
    }

    public class FilterItem
    {
        public string FieldName { get; set; }
        public string Operator { get; set; }
        public object? Value { get; set; }

        public void AddSqlParameters(DynamicParameters dynamicParameters)
        {
            switch (Operator)
            {
                case "between":
                case "not between":
                    var items = (Value as IEnumerable)?.GetEnumerator() ?? throw Errors.InvalidInput(nameof(Value));
                    items.MoveNext();
                    dynamicParameters.Add($"{FieldName}_1", items.Current);
                    items.MoveNext();
                    dynamicParameters.Add($"{FieldName}_2", items.Current);
                    break;
                case "in":
                case "not in":
                    dynamicParameters.Add(FieldName, Value);
                    break;
                case "like":
                    items = (Value as IEnumerable)?.GetEnumerator();
                    items?.MoveNext();
                    dynamicParameters.Add( FieldName, $"%{items?.Current}%");
                    break;
                default:
                    items = (Value as IEnumerable)?.GetEnumerator();
                    items?.MoveNext();
                    dynamicParameters.Add(FieldName, items?.Current);
                    break;
            }
        }

        private string GetOperatorSql() =>
            Operator switch
            {
                "=" => " = ",
                "<" => " < ",
                ">" => " > ",
                ">=" => " >= ",
                "<=" => " <= ",
                "!=" => " != ",
                "<>" => " != ",
                "between" => " BETWEEN ",
                "not between" => " NOT BETWEEN ",
                "like" => " LIKE ",
                "in" => " IN ",
                "not in" => " NOT IN ",
                _ => throw Errors.InvalidInput($"operator = {Operator}")
            };

        private string GetValueSql() =>
            Operator switch
            {
                "between" => $" @{FieldName}_1 AND @{FieldName}_2 ",
                "not between" => $" @{FieldName}_1 AND @{FieldName}_2 ",
                "like" => $" @{FieldName} ",
                _ => $"@{FieldName}",
            };

        public string GetWhereSql(string? fieldName = null) =>
            $"{(string.IsNullOrWhiteSpace(fieldName) ? FieldName : fieldName)} {GetOperatorSql()} {GetValueSql()}";

        public bool IsValid() =>
            !string.IsNullOrWhiteSpace(FieldName) && !string.IsNullOrWhiteSpace(Operator);
    }

    public class DataGridSortInfo
    {
        public string FieldName { get; set; }
        public bool Descending { get; set; }
    }
}
