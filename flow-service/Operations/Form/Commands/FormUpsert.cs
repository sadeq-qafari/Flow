using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Meteor.Extensions;
using Dapper;
using Flow.Core;
using Flow.Core.Models;
using Flow.Operations.Form.Dtos;
using Meteor.Database;
using Meteor.Operation.Db;

namespace Flow.Operations.Form.Commands
{
    public class FormUpsert : DbOperationAsync<FormUpsertInDto, int>
    {
        public string? OldFormName { get; set; }

        protected override async Task PrepareExecutionAsync()
        {
            if (Input.Id > 0)
                OldFormName = await NewSql(sql => sql
                    .Select("[Flow].[Form]", "Name")
                    .WhereThisId()).ExecuteScalarAsync<string>();
        }

        protected override async Task ExecutionAsync()
        {
            Output = await EnsureInTransactionAsync(async () =>
            {
                var dt = Input.Items.AsDataTable("Flow.udt_FormPropertyItem", x => new
                {
                    x.Id,
                    x.LayoutIndex,
                    x.Name,
                    x.Title,
                    x.Type,
                    x.ElementId,
                    x.IsRequired,
                    x.IsAddable,
                    x.IsUpdatable,
                    x.IsFilterable,
                    x.IsHiddenInGrid,
                    x.IsHiddenInForm,
                    x.IsVisibleInDropdown,
                    x.IsUnique,
                    x.IsSensitiveToRepetition,
                    x.IsComputed,
                    x.Rules,
                    x.RelatedFormId,
                    x.RelatedFormPropertyId,
                    x.LookupId,
                    x.Hint,
                    x.DefaultValue,
                    x.CssStyle,
                    x.Placeholder,
                    x.IsActive
                });

                var actionDt = Input.ActionItems.AsDataTable("Flow.udt_FormActionItem", x => new
                {
                    x.Id,
                    x.Name,
                    x.Title,
                    x.ColorHex,
                    x.TypeLookup,
                    x.Script,
                    x.IsActive
                });

                var parameters = new DynamicParameters();
                parameters.Add("Id", Input.Id);
                parameters.Add("Name", Input.Name);
                parameters.Add("Title", Input.Title);
                parameters.Add("Description", Input.Description);
                parameters.Add("Layout", Input.Layout);
                parameters.Add("IsAddable", Input.IsAddable);
                parameters.Add("IsUpdatable", Input.IsUpdatable);
                parameters.Add("IsDeletable", Input.IsDeletable);
                parameters.Add("IsActive", Input.IsActive);
                parameters.Add("TenantId", Input.TenantId);
                parameters.Add("ActionBy", Input.ActionBy);
                parameters.Add("Items", dt.AsTableValuedParameter("Flow.udt_FormPropertyItem"));
                parameters.Add("ActionItems", actionDt.AsTableValuedParameter("Flow.udt_FormActionItem"));

                var res = await NewSql(@"EXECUTE Flow.sp_FormUpsert
                                            @Id = @Id
                                           ,@Name = @Name
                                           ,@Title = @Title
                                           ,@Description = @Description
                                           ,@Layout = @Layout
                                           ,@IsAddable = @IsAddable
                                           ,@IsUpdatable = @IsUpdatable
                                           ,@IsDeletable = @IsDeletable
                                           ,@IsActive = @IsActive
                                           ,@TenantId = @TenantId
                                           ,@ActionBy = @ActionBy
                                           ,@Items = @Items
                                           ,@ActionItems = @ActionItems", parameters).QueryFirstOrDefaultAsync<int>();

                return res;
            }, IsolationLevel.ReadCommitted);
        }

        protected override async Task OnSuccessAsync()
        {
            var ldbConnection = OperationFactory!.GetService<LazyDbConnection>()!;
            await FlowForms.Reload(ldbConnection);

            var formProperties = FlowForms.GetForm(Output)!.Properties;

            if (formProperties == null || !formProperties.Any())
                return;

            List<string> joinQueries = new();
            foreach (var property in formProperties.Where(x => x.RelatedFormId > 0))
            {
                var formName = Input.Name;
                var relatedFormName = property.RelatedFormName;
                var isParent = false;
                if (formName == relatedFormName)
                {
                    relatedFormName += "Parent";
                    isParent = true;
                }

                if (property.Element.Name == "multi_select_input")
                {
                    joinQueries.Add($@"
SELECT
      [{formName}].FormLeadId AS Id
     ,[{relatedFormName}].FormPropertyId{(isParent ? "*-1" : "")}
     ,STRING_AGG([{relatedFormName}].Value,',') AS Value
FROM Flow.FormLeadData [{relatedFormName}]
INNER JOIN Flow.FormLeadData [{formName}]
    ON [{formName}].Value LIKE N'%' + CAST([{relatedFormName}].FormLeadId AS NVARCHAR(MAX)) + N'%'
       AND [{formName}].FormPropertyId = {property.Id}
       AND [{relatedFormName}].FormPropertyId = {property.RelatedFormPropertyId}
GROUP BY [{formName}].FormLeadId, [{relatedFormName}].FormPropertyId{(isParent ? "*-1" : "")}
");
                }
                else
                {
                    joinQueries.Add($@"
SELECT
      [{formName}].FormLeadId AS Id
     ,[{relatedFormName}].FormPropertyId{(isParent ? "*-1" : "")}
     ,[{relatedFormName}].Value
FROM Flow.FormLeadData [{relatedFormName}]
INNER JOIN Flow.FormLeadData [{formName}]
    ON [{formName}].Value = [{relatedFormName}].FormLeadId
       AND [{formName}].FormPropertyId = {property.Id}
       AND [{relatedFormName}].FormPropertyId = {property.RelatedFormPropertyId}
");
                }

                
            }

            foreach (var property in formProperties.Where(x => x.LookupId > 0 && x.Lookup?.TypeLookup == LookupTypeEnum.Options))
            {
                joinQueries.Add($@"
SELECT
      [{Input.Name}].FormLeadId AS Id
     ,[{Input.Name}].FormPropertyId * -1
     ,[{property.Name}].Title
FROM Flow.FormLeadData [{Input.Name}]
INNER JOIN Flow.LookupItem [{property.Name}]
    ON [{Input.Name}].Value = [{property.Name}].Value
       AND [{Input.Name}].FormPropertyId = {property.Id}
       AND [{property.Name}].LookupId = {property.LookupId}
");
            }


            var query = new StringBuilder();

            if (OldFormName?.Length > 0)
            {
                query.Append($"IF OBJECT_ID('[Flow].[v_{OldFormName}_{Input.TenantId}]') IS NOT NULL DROP VIEW [Flow].[v_{OldFormName}]");
                await NewSql(query.ToString()).ExecuteAsync();
            }

            var formSelectQuery =
                $@"SELECT FormLeadId
                ,FormPropertyId
                ,Value
                FROM Flow.FormLeadData 
                INNER JOIN Flow.FormLead ON Flow.FormLeadData.FormLeadId = Flow.FormLead.Id
                WHERE FormLead.IsDeleted = 0 AND FormPropertyId IN ({string.Join(',', formProperties.Select(x => x.Id))})";

            query.Clear();
            query.Append($@"
            CREATE VIEW [Flow].[v_{Input.Name}_{Input.TenantId}]
            AS
            WITH pivot_data AS
            (");
            query.Append(formSelectQuery);
            if (joinQueries.Any())
            {
                query.Append(" UNION ALL " + string.Join(" UNION ALL ", joinQueries));
            }


            var end = $@")
            SELECT FormLeadId AS Id, {string.Join(',', formProperties.Select(GetPropertySqlColNameWithAlias))}, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt, TenantId
            FROM pivot_data
            PIVOT (max(value) FOR FormPropertyId IN ({string.Join(',', formProperties.Select(GetPropertySqlColName))} )) AS FormData
            INNER JOIN Flow.FormLead ON FormLeadId = FormLead.Id
            WHERE  IsDeleted = 0
";

            query.Append(end);

            await NewSql(query.ToString()).ExecuteAsync();
        }

        private string GetPropertySqlColNameWithAlias(FormPropertyModel property)
        {
            var colName = $"[{property.Id}] AS [{property.Name}]";
            if (property.RelatedFormId > 0)
            {
                colName +=
                    $", [{(property.FormId == property.RelatedFormId ? "-" : "")}{property.RelatedFormPropertyId}] AS [{property.RelatedFormName}{property.RelatedFormPropertyName}]";
            }

            if (property.LookupId > 0 && property.Lookup?.TypeLookup == LookupTypeEnum.Options)
            {
                colName += $", [-{property.Id}] AS [{property.Name}Title]";
            }

            return colName;
        }

        private string GetPropertySqlColName(FormPropertyModel property)
        {
            var colName = $"[{property.Id}]";
            if (property.RelatedFormId > 0)
            {
                colName += $", [{(property.FormId == property.RelatedFormId ? "-" : "")}{property.RelatedFormPropertyId}]";
            }

            if (property.LookupId > 0 && property.Lookup?.TypeLookup == LookupTypeEnum.Options)
            {
                colName += $", [-{property.Id}]";
            }

            return colName;
        }
    }
}
