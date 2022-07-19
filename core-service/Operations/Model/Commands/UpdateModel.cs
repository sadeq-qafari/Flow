using Core.Meteor;
using Core.Operations.Model.Dto;

namespace Core.Operations.Model.Commands
{
    public class UpdateModel : DbUpdateAsync<UpdateModelInDto>
    {
        public UpdateModel() : base("[Core].[Model]",
            "[ServiceId]=@ServiceId, [Name]=@Name, [Title]=@Title, [HasCustomUpsertForm]=@HasCustomUpsertForm, [Insert]=@Insert, [Read]=@Read, [Update]=@Update, [Delete]=@Delete, [JsInputMapper]=@JsInputMapper, [JsOutputMapper]=@JsOutputMapper, [JsController]=@JsController, [IsReport]=@IsReport, [ReportQuery]=@ReportQuery, [ReportDbServerId]=@ReportDbServerId")
        {
        }
    }
}
