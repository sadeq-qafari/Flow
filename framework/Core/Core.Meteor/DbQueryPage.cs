using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Meteor.Dto;
using Core.Meteor.Extensions;
using Dapper;
using Meteor.Database.SqlDialect;
using Meteor.Operation.Db;

namespace Core.Meteor
{
    public class DbQueryPage<T> : DbQueryPageAsync<DbQueryPageInDto, T>, IHaveTableName
    {
        protected readonly DynamicParameters Parameters = new();

        public string TableName { get; set; }
        private readonly string? _modelName;

        public DbQueryPage() : this("")
        {
        }

        public DbQueryPage(string tableName, string? modelName = null)
        {
            TableName = tableName;
            _modelName = modelName;
        }

        public DbQueryPage<T> SetTableName(string tableName)
        {
            TableName = tableName;
            return this;
        }

        protected override async Task ExecutionAsync()
        {
            var filterItems = GetFilterItems();
            var sort = GetSortItems();

            Parameters.Add("Take", Input.Take);
            Parameters.Add("Offset", Input.Offset);
            Parameters.Add("Tenant_Id", Input.TenantId);
            Parameters.Add("Branch_Id", Input.BranchId);
            Parameters.Add("ActionBy", Input.ActionBy);
            foreach (var filterItem in filterItems)
                filterItem.AddSqlParameters(Parameters);

            var selectItems = GetSelectSql()
                .Where(x => BuildWhere(x, filterItems))
                .OrderBy(GetOrderBySql(sort));

            var selectCount = GetSelectSql(true)
                .Where(x => BuildWhere(x, filterItems));

            Output = await SelectQueryPageAsync(selectItems, selectCount);
        }

        private IEnumerable<DataGridSortInfo> GetSortItems() =>
            Input.Sort?.Split(',').Select(x =>
            {
                var parts = x.Split(' ');
                return new DataGridSortInfo
                {
                    FieldName = parts[0].Trim(),
                    Descending = parts.Length > 1 && parts[1].Trim().ToLowerInvariant() == "desc"
                };
            }) ?? new List<DataGridSortInfo>();

        private async Task<QueryPage<T>> SelectQueryPageAsync(ISqlDialect selectItems, ISqlDialect selectCount)
        {
            IEnumerable<T> items = await NewSql(sql => Input.Paging ? selectItems.AddPagination() : selectItems, Parameters).QueryAsync<T>();
            var totalCount = await NewSql(sql => selectCount, Parameters).ExecuteScalarAsync<long>();
            return this.CreateQueryPage(items, totalCount);
        }

        protected virtual string GetOrderBySql(IEnumerable<DataGridSortInfo> sortInfo)
        {
            return Input.Sort != null
                ? string.Join(',', sortInfo.Select(x => $"{GetFieldName(x.FieldName)} {(x.Descending ? "DESC" : "ASC")}"))
                : $"{GetFieldName("id")} DESC";
        }

        protected virtual void BuildWhere(SqlWhereBuilder builder, List<FilterItem> filterItems)
        {
            builder.Where($"{GetFieldName("IsDeleted")}=0 AND ({GetFieldName("TenantId")}=0 OR {GetFieldName("TenantId")}=@Tenant_Id OR {GetFieldName("TenantId")} IS NULL)");
            if (!filterItems.Any())
                return;
            foreach (var filterItem in filterItems.Where(x => x.IsValid()))
                builder.And(filterItem.GetWhereSql(GetFieldName(filterItem.FieldName)));
        }

        protected virtual ISqlDialect GetSelectSql(bool isForCount = false) =>
            SqlFactory!.Create().Select(TableName, isForCount ? "COUNT(*)" : "*");

        private List<FilterItem> GetFilterItems()
        {
            var items = new List<FilterItem>();
            var decodedFilter = WebUtility.UrlDecode(Input.Filter);
            if (string.IsNullOrWhiteSpace(decodedFilter))
                return items;

            var res = JsonSerializer.Deserialize<List<List<JsonElement>>>(decodedFilter);
            if (res == null)
                return items;

            foreach (var item in res)
            {
                var fItem = new FilterItem
                {
                    FieldName = item[0].GetString()!,
                    Operator = item[1].GetString()!,
                    Value = null
                };
                List<object> value = item[2]
                    .EnumerateArray()
                    .Select(v => (object) (v.ValueKind switch
                    {
                        JsonValueKind.String => v.GetString()!,
                        JsonValueKind.Number => v.GetInt32()!,
                        JsonValueKind.False => v.GetBoolean()!,
                        JsonValueKind.True => v.GetBoolean()!
                    }))
                    .ToList();

                fItem.Value = value.Count > 0 ? value.CastAndList(value.First().GetType())! : null;
                items.Add(fItem);
            }

            return items;
        }

        protected virtual string GetFieldName(string fieldName) =>
            $"[{fieldName}]" ;
    }
}
