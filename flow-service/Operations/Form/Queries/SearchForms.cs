using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flow.Core;
using Flow.Core.Models;
using Meteor.Operation.Db;
using Saanaa.Core.Meteor;

namespace Flow.Operations.Form.Queries
{
    public class SearchForms : DbOperationAsync<SearchFormsInDto, Dictionary<string, IEnumerable<object>>>
    {
        protected override async Task ExecutionAsync()
        {
            Output = new Dictionary<string, IEnumerable<object>>();
            if (string.IsNullOrEmpty(Input.SearchValue.Trim()))
                return;

            var tasks = new List<Tuple<string, Task<IEnumerable<object>>>>();
            foreach (var form in SaanaaForms.Forms)
            {
                var where = GetFormWhere(form.Properties);
                if (where.Length <= 0)
                    continue;

                where = $"({where}) AND TenantId = @TenantId";
                var task = NewSql(sql => sql.Select($"[Flow].[v_{form.Name}]").Where(where)).QueryAsync<object>();
                tasks.Add(new Tuple<string, Task<IEnumerable<object>>>(form.Name!, task));
            }

            var res = (await Task.WhenAll(tasks.Select(x => x.Item2))).ToList();


            for (int i = 0; i < res.Count; i++)
                if (res[i].Any())
                    Output.Add(tasks[i].Item1, res[i]);
        }

        private string GetFormWhere(List<FormPropertyModel> properties)
        {
            var props = properties.Where(x => new List<string>() { "string", "text" }
                .Contains(x.Type) || x.RelatedFormId > 0 || x.LookupId > 0);
            var colWheres = new List<string>();
            foreach (var prop in props)
            {
                if (prop.RelatedFormId > 0)
                {
                    colWheres.Add($"[{prop.RelatedFormName}{prop.RelatedFormPropertyName}] LIKE N'%' + @SearchValue + N'%'");
                }
                else if (prop.LookupId > 0)
                {
                    colWheres.Add($"[{prop.Name}Title] LIKE N'%' + @SearchValue + N'%'");
                }
                else
                {
                    colWheres.Add($"[{prop.Name}] LIKE N'%' + @SearchValue + N'%'");
                }
            }

            return string.Join(" OR ", colWheres);
        }
    }

    public class SearchFormsInDto : IHaveTenant
    {
        public string? SearchValue { get; set; }
        public int? TenantId { get; set; }
    }
}
