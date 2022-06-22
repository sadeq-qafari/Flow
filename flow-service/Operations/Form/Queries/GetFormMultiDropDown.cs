using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Flow.Core;
using Flow.Core.Models;
using Meteor.Operation.Db;
using Meteor.Utils;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Form.Queries
{
    public class GetFormMultiDropDown : DbOperationAsync<FormMultiDropDownInDto, IEnumerable<object>>
    {
        public FormModel Form { get; set; }
        public DynamicParameters Parameters { get; set; } = new();

        protected override Task<FormMultiDropDownInDto> PrepareInputAsync()
        {
            Input.SearchValue ??= "";
            return Task.FromResult(Input);
        }

        protected override async Task ExecutionAsync()
        {
            Form = SaanaaForms.GetForm(Input.FormName) ?? throw Errors.NotFound();

            var colNames =
                Form.Properties!
                    .Where(x => x!.IsVisibleInDropdown)
                    .Select(x => $"[{x!.Name}]").ToList();


            Output = await NewSql(sql => sql
                    .Select($"[Flow].[v_{Form.Name}]", string.Join(",", new[] {"[Id]"}.Concat(colNames)))
                    .Where(GetWhere()), new
                {
                    Input.FormName,
                    Input.SearchValue,
                    Input.TenantId,
                    Ids = !string.IsNullOrEmpty(Input.Ids?.Trim()) ? Input.Ids.Split(',') : null
                })
                .QueryAsync<object>();
        }

        private string GetWhere()
        {
            if (Input.Ids != null)
                return "[Id] IN @Ids AND [TenantId]=@TenantId";

            var searchValueWhereItems = new List<string>();
            foreach (var prop in Form.Properties)
            {
                searchValueWhereItems.Add(
                    $"ISNULL(CAST([{prop.Name}] AS NVARCHAR(MAX)),N'') LIKE N'%' + @SearchValue + N'%'");
            }

            var res = string.Join(" OR ", searchValueWhereItems);
            res = res.Length > 0 ? $"({res}) AND [TenantId]=@TenantId" : "[TenantId]=@TenantId";

            return res;
        }
    }

    public class FormMultiDropDownInDto : IHaveTenant
    {
        public string? FormName { get; set; }
        public string? SearchValue { get; set; }
        public string? Ids { get; set; }
        public int? TenantId { get; set; }
    }
}