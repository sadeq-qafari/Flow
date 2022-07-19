using Core.Meteor;
using Flow.Operations.FormProperty.Dtos;
using Meteor.Database.SqlDialect;

namespace Flow.Operations.FormProperty.Queries
{
    public class GetFormPropertyPage : DbQueryPage<FormPropertyDto>
    {
        public GetFormPropertyPage() : base("[Flow].[FormProperty]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            
            return SqlFactory!.Create().Select("[Flow].[FormProperty] FormProperty", isForCount ? "COUNT(*)" : @"
						FormProperty.*, 
						Form.Title AS FormTitle,
						Element.Title AS ElementTitle,
						IsHiddenInGri.Title AS IsHiddenInGridTitle,
						RelatedForm.Title AS RelatedFormTitle,
						RelatedFormProperty.Title AS RelatedFormPropertyTitle,
						Lookup.Title AS LookupTitle")
                .LeftJoin("[Flow].[Form] Form",  "FormProperty.FormId = Form.Id  AND  Form.IsDeleted=0")
                .LeftJoin("[Flow].[Element] Element",  "FormProperty.ElementId = Element.Id  AND  Element.IsDeleted=0")
                .LeftJoin("[Flow].[FormProperty] IsHiddenInGri",  "FormProperty.IsHiddenInGrid = IsHiddenInGri.Id  AND  IsHiddenInGri.IsDeleted=0")
                .LeftJoin("[Flow].[FormProperty] RelatedForm",  "FormProperty.RelatedFormId = RelatedForm.Id  AND  RelatedForm.IsDeleted=0")
                .LeftJoin("[Flow].[FormProperty] RelatedFormProperty",  "FormProperty.RelatedFormPropertyId = RelatedFormProperty.Id  AND  RelatedFormProperty.IsDeleted=0")
                .LeftJoin("[Flow].[Lookup] Lookup",  "FormProperty.LookupId = Lookup.Id  AND  Lookup.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[FormProperty].[{fieldName}]";
    }
}