using Identity.Operations.Database.TenantRegisterRequest.Dtos;
using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.TenantRegisterRequest.Queries
{
    public class GetTenantRegisterRequestPage : SaanaaDbQueryPage<TenantRegisterRequestDto>
    {
        public GetTenantRegisterRequestPage() : base("[Identity].[TenantRegisterRequest]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            Parameters.Add("StatusLookup", SaanaaServices.GetModelProperty("Identity","TenantRegisterRequest","statusLookup")!.Id);
            Parameters.Add("OrganizationActivityType", SaanaaServices.GetModelProperty("Identity","TenantRegisterRequest","organizationActivityType")!.Id);
			Parameters.Add("OrganizationTypeLookup", SaanaaServices.GetModelProperty("Identity","TenantRegisterRequest","organizationTypeLookup")!.Id);
			Parameters.Add("OrganizationCustomTypeLookup", SaanaaServices.GetModelProperty("Identity","TenantRegisterRequest","organizationCustomTypeLookup")!.Id);
			Parameters.Add("PersonRelationTypeLookup", SaanaaServices.GetModelProperty("Identity","TenantRegisterRequest","personRelationTypeLookup")!.Id);
			Parameters.Add("PersonCustomRelationTypeLookup", SaanaaServices.GetModelProperty("Identity","TenantRegisterRequest","personCustomRelationTypeLookup")!.Id);
            return SqlFactory!.Create().Select("[Identity].[TenantRegisterRequest] TenantRegisterRequest", isForCount ? "COUNT(*)" : @"
						TenantRegisterRequest.*, 
						StatusLookup.Title AS StatusLookupTitle,
						OrganizationActivityType.Title AS OrganizationActivityTypeTitle, 
						OrganizationTypeLookup.Title AS OrganizationTypeLookupTitle,
						OrganizationCustomTypeLookup.Title AS OrganizationCustomTypeLookupTitle,
						PersonRelationTypeLookup.Title AS PersonRelationTypeLookupTitle,
						PersonCustomRelationTypeLookup.Title AS PersonCustomRelationTypeLookupTitle")
                .LeftJoin("[Core].[ModelPropertyLookup] StatusLookup",  "TenantRegisterRequest.StatusLookup = StatusLookup.Value AND StatusLookup.ModelPropertyId=@StatusLookup  AND  StatusLookup.IsDeleted=0")
                .LeftJoin("[Core].[ModelPropertyLookup] OrganizationActivityType",  "TenantRegisterRequest.OrganizationActivityType = OrganizationActivityType.Value AND OrganizationActivityType.ModelPropertyId=@OrganizationActivityType  AND  OrganizationActivityType.IsDeleted=0")
                .LeftJoin("[Core].[ModelPropertyLookup] OrganizationTypeLookup",  "TenantRegisterRequest.OrganizationTypeLookup = OrganizationTypeLookup.Value AND OrganizationTypeLookup.ModelPropertyId=@OrganizationTypeLookup  AND  OrganizationTypeLookup.IsDeleted=0")
                .LeftJoin("[Core].[ModelPropertyLookup] OrganizationCustomTypeLookup",  "TenantRegisterRequest.OrganizationCustomTypeLookup = OrganizationCustomTypeLookup.Value AND OrganizationCustomTypeLookup.ModelPropertyId=@OrganizationCustomTypeLookup  AND  OrganizationCustomTypeLookup.IsDeleted=0")
                .LeftJoin("[Core].[ModelPropertyLookup] PersonRelationTypeLookup",  "TenantRegisterRequest.PersonRelationTypeLookup = PersonRelationTypeLookup.Value AND PersonRelationTypeLookup.ModelPropertyId=@PersonRelationTypeLookup  AND  PersonRelationTypeLookup.IsDeleted=0")
                .LeftJoin("[Core].[ModelPropertyLookup] PersonCustomRelationTypeLookup",  "TenantRegisterRequest.PersonCustomRelationTypeLookup = PersonCustomRelationTypeLookup.Value AND PersonCustomRelationTypeLookup.ModelPropertyId=@PersonCustomRelationTypeLookup  AND  PersonCustomRelationTypeLookup.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[TenantRegisterRequest].[{fieldName}]";
    }
}