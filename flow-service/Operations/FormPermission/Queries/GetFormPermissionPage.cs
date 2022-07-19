using Core.Meteor;
using Flow.Operations.FormPermission.Dtos;
using Meteor.Database.SqlDialect;

namespace Flow.Operations.FormPermission.Queries
{
    public class GetFormPermissionPage : DbQueryPage<FormPermissionDto>
    {
        public GetFormPermissionPage() : base("[Flow].[FormPermission]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            Parameters.Add("PermissionTypeLookup", SqServices.GetModelProperty("Flow","FormPermission","permissionTypeLookup")!.Id);
            return SqlFactory!.Create().Select("[Flow].[FormPermission] FormPermission", isForCount ? "COUNT(*)" : @"
						FormPermission.*, 
						Role.Title AS RoleTitle,
						Form.Title AS FormTitle,
						PermissionTypeLookup.Title AS PermissionTypeLookupTitle,
						FormAction.Title AS FormActionTitle")
                .LeftJoin("[Identity].[Role] Role",  "FormPermission.RoleId = Role.Id  AND  Role.IsDeleted=0")
                .LeftJoin("[Flow].[Form] Form",  "FormPermission.FormId = Form.Id  AND  Form.IsDeleted=0")
                .LeftJoin("[Core].[ModelPropertyLookup] PermissionTypeLookup",  "FormPermission.PermissionTypeLookup = PermissionTypeLookup.Value AND PermissionTypeLookup.ModelPropertyId=@PermissionTypeLookup  AND  PermissionTypeLookup.IsDeleted=0")
                .LeftJoin("[Flow].[FormAction] FormAction",  "FormPermission.FormActionId = FormAction.Id  AND  FormAction.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[FormPermission].[{fieldName}]";
    }
}