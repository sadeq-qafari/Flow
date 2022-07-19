using System;
using System.Threading.Tasks;
using Meteor.Operation.Db;
using Meteor.Utils;
using Core.Meteor;
using Tenant.Operations.EntityTag.Dtos;

namespace Tenant.Operations.EntityTag.Commands
{
    public class EntityTagMerge : DbOperationAsync<EntityTagMergeInDto, bool>,INeedLog,IHaveTableName
    {
        public string TableName { get; set; } = "[Tenant].[EntityTag]";
        protected override async Task ExecutionAsync()
        {
            var tagIds = string.Empty;
            var modelId = SqServices.GetModel(Input.ServiceName, Input.ModelName)?.Id;
            if (modelId == null)
                throw Errors.InvalidInput("entity_tag_model_not_found");
            if (Input.TagIds?.Count > 0) tagIds = string.Join(',', Input.TagIds!);

            try
            {
                await NewSql(@"EXECUTE Tenant.sp_EntityTagMerge @EntityId = @EntityId
                                ,@ModelId = @ModelId
                                ,@ActionBy = @ActionBy
                                ,@TagIds = @TagIds
                                ,@TenantId = @TenantId", new
                {
                    EntityId = Input.EntityId,
                    ModelId = modelId,
                    ActionBy = Input.CreatedBy,
                    TagIds = tagIds,
                    TenantId = Input.TenantId
                }).ExecuteAsync();
            }
            catch (Exception e)
            {
                throw Errors.InvalidOperation("entity_tag_merge_failed");
            }

            Output = true;
        }

    }
}
