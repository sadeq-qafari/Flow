using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Flow.Core.Models;
using Meteor.Database;
using Meteor.Utils;
using NodaTime;

namespace Flow.Core
{
    public static class SaanaaForms
    {
        public static long LatestVersion;
        public static List<FormModel> Forms { get; private set; } = new List<FormModel>();

        public static async Task Reload(LazyDbConnection lazyDbConnection)
        {
            const string sqlText =
                @"
                    SELECT * FROM Flow.Form WHERE IsDeleted=0;
                    SELECT * FROM Flow.FormProperty WHERE IsDeleted=0 ORDER BY [LayoutIndex] ASC;
                    SELECT * FROM Flow.FormAction WHERE IsDeleted=0;
                    SELECT * FROM Flow.Element WHERE IsDeleted=0;
                    SELECT * FROM Flow.Lookup WHERE IsDeleted=0;
                    SELECT * FROM Flow.LookupItem WHERE IsDeleted=0 ORDER BY [Index] ASC;
                ";

            var db = await lazyDbConnection.GetConnectionAsync();
            var grid = await db.QueryMultipleAsync(sqlText);
            var forms = await grid.ReadAsync<FormModel>().ToListAsync();
            var formProperties = await grid.ReadAsync<FormPropertyModel>().ToListAsync();
            var formActions = await grid.ReadAsync<FormActionModel>().ToListAsync();
            var formElements = await grid.ReadAsync<ElementModel>().ToListAsync();
            var lookups = await grid.ReadAsync<LookupModel>().ToListAsync();
            var lookupItems = await grid.ReadAsync<LookupItemModel>().ToListAsync();

            foreach (var form in forms)
            {
                form.Properties = formProperties.Where(x => x.FormId == form.Id).ToList();
                form.Actions = formActions.Where(x => x.FormId == form.Id).ToList();
            }

            foreach (var lookup in lookups.Where(x => x.TypeLookup == LookupTypeEnum.Options))
            {
                lookup.Options = lookupItems.Where(x => x.LookupId == lookup.Id).ToList();
            }

            foreach (var property in formProperties)
            {
                if (property.ElementId > 0)
                {
                    property.Element = formElements.Find(x => x.Id == property.ElementId)!;
                }

                if (property.RelatedFormId > 0)
                {
                    property.RelatedFormName = forms.Find(x => x.Id == property.RelatedFormId)?.Name;
                    property.RelatedFormPropertyId = forms.Find(x => x.Id == property.RelatedFormId)?.Properties
                        ?.Where(x => x.IsVisibleInDropdown).FirstOrDefault()?.Id;
                    property.RelatedFormPropertyName = forms.Find(x => x.Id == property.RelatedFormId)?.Properties
                        ?.Where(x => x.IsVisibleInDropdown).FirstOrDefault()?.Name;
                }

                if (property.LookupId > 0)
                {
                    property.Lookup = lookups.FirstOrDefault(x => x.Id == property.LookupId);
                }
            }

            Forms = forms;
            LatestVersion = SystemClock.Instance.GetCurrentInstant().ToUnixTimeSeconds();
        }

        public static IEnumerable<FormModel> GetForms(int? tenantId) =>
            Forms.Where(x => x.TenantId == tenantId);

        public static FormModel? GetForm(string? name) =>
            Forms.FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase));

        public static FormModel? GetForm(int? formId) =>
            Forms.FirstOrDefault(x => x.Id == formId);

        public static FormPropertyModel? GetFormProperty(string? formName, string? formPropertyName) =>
            GetForm(formName)?.Properties
                .FirstOrDefault(x => string.Equals(x.Name, formName, StringComparison.InvariantCultureIgnoreCase));
    }
}
