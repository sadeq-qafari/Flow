using System.Threading.Tasks;
using Core.Operations.Model.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.Model.Commands
{
    public class AddModel : SaanaaDbInsertAsync<AddModelInDto>
    {
        protected override Task PrepareExecutionAsync()
        {
            Input.TenantId = 0;
            return Task.CompletedTask;
        }

        public AddModel() : base("[Core].[Model]",
            "[ServiceId], [Name], [Title], [HasCustomUpsertForm], [Insert], [Read], [Update], [Delete], [JsInputMapper], [JsOutputMapper], [JsController], [IsReport], [ReportQuery], [ReportDbServerId]",
            "@ServiceId, @Name, @Title, @HasCustomUpsertForm, @Insert, @Read, @Update, @Delete, @JsInputMapper, @JsOutputMapper, @JsController, @IsReport, @ReportQuery, @ReportDbServerId")
        {
        }
    }
}

