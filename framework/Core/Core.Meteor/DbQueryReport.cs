using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Meteor.Dto;
using Core.Meteor.Extensions;
using Core.Meteor.Models;
using Dapper;
using Meteor.Database.SqlDialect;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Core.Meteor
{
    public class DbQueryReport<T> : DbQueryPageAsync<DbQueryReportInDto, T>
    {
        protected readonly DynamicParameters Parameters = new();

        public Model? Model { get; set; }
        public Dictionary<string, object>? ReportParams { get; set; }

        protected override async Task ExecutionAsync()
        {
            Model = SqServices.GetModel(Input.ServiceName, Input.ModelName);
            ReportParams = Input.ReportParams;
            if (Model == null)
                throw Errors.InvalidInput("model_not_found");
            if (!Model.IsReport)
                throw Errors.InvalidInput("model_is_not_a_report");
            if (string.IsNullOrWhiteSpace(Model.ReportQuery))
                throw Errors.InvalidInput("report_query_not_defined");

            var filterItems = GetFilterItems();
            var sort = GetSortItems();
            Parameters.Add("Take", Input.Take);
            Parameters.Add("Offset", Input.Offset);
            Parameters.Add("TenantId", Input.TenantId);
            var modelParams = Model.Properties.Where(x => x.Insertable).ToList();
            foreach (var property in modelParams)
                Parameters.Add(property.Name,
                    GetParamValue(ReportParams?.FirstOrDefault(x => x.Key == property.Name).Value));

            foreach (var filterItem in filterItems)
                filterItem.AddSqlParameters(Parameters);

            if (Model!.ReportQuery?.ToLowerInvariant().Contains("@report") == true)
            {
                var where = new SqlWhereBuilder();
                BuildWhere(where, filterItems);
                var whereStr = string.IsNullOrWhiteSpace(where.SqlText) ? "" : $"WHERE {where.SqlText}";
                var query = SqlFactory!.Create().AppendSql(Model!.ReportQuery).EndStatement()
                    .Select("@Report AS Report", "COUNT(*)")
                    .Where(x => BuildWhere(x, filterItems))
                    .EndStatement()
                    .Select("@Report AS Report")
                    .Where(x => BuildWhere(x, filterItems))
                    .OrderBy(GetOrderBySql(sort));
                
                if(Input.Paging) query = query.AddPagination();
                
                var conn = await LazyDbConnection!.GetConnectionAsync();
                var gridReader =  await conn.QueryMultipleAsync(query.SqlText, param: Parameters, commandType: CommandType.Text);
                var totalCount = await gridReader.ReadFirstOrDefaultAsync<int>();
                var items = await gridReader.ReadAsync<T>();

                if (!Input.Paging)
                {
                    Output = new QueryPage<T>(items, 1, totalCount, totalCount);
                }
                else
                {
                    Output = new QueryPage<T>(items, Input.Page, Input.Take, totalCount);
                }


                return;
            }

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
            IEnumerable<T> items = await NewSql(sql => Input.Paging ? selectItems.AddPagination() : selectItems, Parameters)
                .QueryAsync<T>();
            var totalCount = await NewSql(sql => selectCount, Parameters).ExecuteScalarAsync<long>();
            return this.CreateQueryPage(items, totalCount);
        }

        protected virtual string GetOrderBySql(IEnumerable<DataGridSortInfo> sortInfo)
        {
            return !string.IsNullOrWhiteSpace(Input.Sort)
                ? string.Join(',', sortInfo.Select(x => $"{GetFieldName(x.FieldName)} {(x.Descending ? "DESC" : "ASC")}"))
                : $"{GetFieldName(Model!.Properties.Where(x => x.Visible)!.First().Name)} DESC";
        }

        protected virtual void BuildWhere(SqlWhereBuilder builder, List<FilterItem> filterItems)
        {
            if (!filterItems.Any())
                return;
            foreach (var filterItem in filterItems.Where(x => x.IsValid()))
                builder.And(filterItem.GetWhereSql(GetFieldName(filterItem.FieldName)));
        }

        protected virtual ISqlDialect GetSelectSql(bool isForCount = false)
        {
            var sql = SqlFactory!.Create();
            sql.SqlText = $@"SELECT {(isForCount ? "COUNT(*)" : "*")} FROM ({Model!.ReportQuery!}) AS Report";
            return sql;
        }

        private object? GetParamValue(object? value)
        {
            if (value == null)
                return null;

            var val = (JsonElement) value;
            return val.ValueKind switch
            {
                JsonValueKind.String => val.GetString()!,
                JsonValueKind.Number => val.GetInt32()!,
                JsonValueKind.False => val.GetBoolean()!,
                JsonValueKind.True => val.GetBoolean()!,
                JsonValueKind.Array => val.EnumerateArray()
                    .Select(v => GetParamValue(v)).ToList()
                    .CastAndList(val.EnumerateArray().Select(v => GetParamValue(v))
                        .ToList().First()!.GetType())!,

                _ => val.GetString()!
            };
        }


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
            $"Report.[{fieldName}]";
    }
}
