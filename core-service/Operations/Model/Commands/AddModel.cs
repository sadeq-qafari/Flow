using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.Model.Dto;

namespace Core.Operations.Model.Commands
{
    public class AddModel : DbInsertAsync<AddModelInDto>
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

