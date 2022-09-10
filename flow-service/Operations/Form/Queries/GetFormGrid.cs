using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flow.Core;
using Flow.Core.Models;
using Flow.Operations.Form.Dtos;
using Humanizer;
using Meteor.Database.SqlDialect;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Flow.Operations.Form.Queries
{
    public class GetFormGrid : DbQueryPageAsync<GetFormGridInDto, object>
    {
        public string FormName { get; set; }

        protected override Task<GetFormGridInDto> PrepareInputAsync()
        {
            if (string.IsNullOrEmpty(Input.Sort?.Trim()))
            {
                Input.Sort = "Id DESC";
            }
            else
            {
                var parts = Input.Sort.Split('_');
                Input.Sort = $"[{parts[0].Pascalize()}] {(parts.Length > 1 ? parts[1] : "ASC")}";
            }

            if (Input.Page <= 0) Input.Page = 1;
            if (Input.Take <= 0) Input.Take = 10;

            return Task.FromResult<GetFormGridInDto>(Input);
        }

        protected override async Task ExecutionAsync()
        {
            FormName = FlowForms.GetForm(Input.FormName)?.Name ?? throw Errors.NotFound("form_not_found");

            var totalCount = await NewSql(GetSelectSql(true).SqlText)
                .ExecuteScalarAsync<int>();

            var items = totalCount > 0
                ? await NewSql(GetSelectSql(false).SqlText).QueryAsync<object>()
                : new List<object>();

            Output = this.CreateQueryPage(items, totalCount);
        }

        public ISqlDialect GetSelectSql(bool isForCount)
        {
            var sql = SqlFactory!.Create().Select($"[Flow].[v_{FormName}]", isForCount ? "Count(1)" : "*")
                .Where(wh =>
                    wh.Where("TenantId=@TenantId")
                        .When(!string.IsNullOrEmpty(Input.Filter?.Trim()), GetFilter()));

            if (isForCount) return sql;

            sql = sql.OrderBy(Input.Sort!);

            if (Input.Paging)
                sql = sql.AddPagination();

            return sql;
        }

        private string GetFilter()
        {
            List<FormPropertyModel> properties = FlowForms.GetForm(Input.FormName)!.Properties!;
            var props = properties.Where(x => new List<string>() { "string", "text" }
                .Contains(x.Type) || x.RelatedFormId > 0 || x.LookupId > 0);
            var colWheres = new List<string>();
            foreach (var prop in props)
            {
                if (prop.RelatedFormId > 0)
                {
                    colWheres.Add($"[{prop.RelatedFormName}{prop.RelatedFormPropertyName}] LIKE N'%' + @Filter + N'%'");
                }
                else if (prop.LookupId > 0)
                {
                    colWheres.Add($"[{prop.Name}Title] LIKE N'%' + @Filter + N'%'");
                }
                else
                {
                    colWheres.Add($"[{prop.Name}] LIKE N'%' + @Filter + N'%'");
                }
            }

            return string.Join(" OR ", colWheres);
        }
    }
}
