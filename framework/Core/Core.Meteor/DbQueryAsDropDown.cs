using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Meteor.Dto;
using Dapper;
using Humanizer;
using Meteor.Database.SqlDialect;
using Meteor.Operation.Db;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Core.Meteor
{
    public class DbQueryAsDropDown<T> : DbOperationAsync<DbQueryAsDropDownInDto, IEnumerable<DropDownDto<object>>>,
        IHaveTableName
    {
        private static JsonSerializerOptions? _jsonSerializerSettings;
        //TODO: SQL Injection test

        public string TableName { get; set; }
        private readonly string _titleColumnName;
        private readonly string _valueColumnName;
        private readonly string[] _tagPropertyNames;

        public DbQueryAsDropDown(string tableName, string titleColumnName = "Title",
            string valueColumnName = "Id", params string[] tagPropertyNames)
        {
            if (_jsonSerializerSettings == null)
            {
                _jsonSerializerSettings = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                _jsonSerializerSettings.Converters.Add(new JsonElementToInferredTypeConverter());
            }

            TableName = tableName;
            _titleColumnName = titleColumnName;
            _valueColumnName = valueColumnName;
            _tagPropertyNames = tagPropertyNames;
        }

        protected override async Task ExecutionAsync()
        {
            var parameters = new DynamicParameters();
            var ids = GetIdsAsList();
            var items = Input.Ids != null
                ? await GetItems(x => GetIdsWhere(x, ids), new {Ids = ids, Input.TenantId})
                : await GetItems(x => GetSearchValueWhere(AddInputFilters(x, parameters)),
                    parameters);

            Output = GetOutput(items);
        }

        private IEnumerable<DropDownDto<object>> GetOutput(IEnumerable<T> items)
        {
            var titlePropertyInfo = typeof(T).GetProperty(_titleColumnName);
            var valuePropertyInfo = typeof(T).GetProperty(_valueColumnName);
            var tagPropertyInfos = typeof(T).GetProperties()
                .Where(x => _tagPropertyNames.Contains(x.Name));

            return items.Select(x =>
            {
                var dict = new Dictionary<string, object?> {{"title", titlePropertyInfo!.GetValue(x)!}};
                foreach (var tagPropertyInfo in tagPropertyInfos)
                    dict.Add(tagPropertyInfo.Name.Camelize(), tagPropertyInfo.GetValue(x));

                return new DropDownDto<object>
                {
                    Label = dict,
                    Value = valuePropertyInfo!.GetValue(x)!
                };
            });
        }

        private SqlWhereBuilder AddInputFilters(SqlWhereBuilder wb, DynamicParameters parameters)
        {
            parameters.Add("TenantId", Input.TenantId);

            if (string.IsNullOrWhiteSpace(Input.Filters))
                return wb;

            var filters = JsonSerializer.Deserialize<List<DropDownFilterDto>>(Input.Filters, _jsonSerializerSettings);
            if (filters == null || filters.Count <= 0)
                return wb;

            foreach (var filter in filters)
            {
                wb.Where($"{GetFieldName(filter.Name)}=@{filter.Name}");
                parameters.Add(filter.Name, filter.Value);
            }

            return wb;
        }

        protected virtual void GetSearchValueWhere(SqlWhereBuilder wb) =>
            wb.When(!string.IsNullOrWhiteSpace(Input.SearchValue),
                $"{GetFieldName(_titleColumnName)} Like N'%{Input.SearchValue?.Trim()}%' ");

        protected virtual void GetIdsWhere(SqlWhereBuilder wb, List<string> ids) =>
            wb.When(ids.Count > 0, $"{GetFieldName(_valueColumnName)} IN @Ids");

        protected virtual Task<IEnumerable<T>> GetItems(Action<SqlWhereBuilder>? extraWhere = null, object? parameters = null,
            string? orderBy = null) =>
            NewSql(sql => GetSelectSql(sql)
                .Where(wb =>
                {
                    extraWhere?.Invoke(GetWhereSql(wb));
                    GetWhereSql(wb);
                })
                .OrderBy(orderBy ?? $"{_valueColumnName} DESC")
                .Offset("0", "10"), parameters ?? Input).QueryAsync<T>();

        protected virtual ISqlDialect GetSelectSql(ISqlDialect sql) =>
            sql.Select(TableName, $"{_valueColumnName}, {_titleColumnName}");

        protected virtual SqlWhereBuilder GetWhereSql(SqlWhereBuilder whereBuilder) =>
            whereBuilder.Where($"{GetFieldName("IsDeleted")}=0 AND ({GetFieldName("TenantId")}=0 OR {GetFieldName("TenantId")}=@TenantId OR {GetFieldName("TenantId")} IS NULL)");

        private List<string> GetIdsAsList() =>
            !string.IsNullOrWhiteSpace(Input.Ids)
                ? Input.Ids.Split(',').Select(x=>x.ToString()).ToList()
                : new List<string>();

        protected virtual string GetFieldName(string fieldName) =>
            $"[{fieldName}]" ;
    }
}
