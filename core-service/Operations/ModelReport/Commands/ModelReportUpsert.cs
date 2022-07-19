using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.ModelReport.Dtos;
using Meteor.Operation.Db;

namespace Core.Operations.ModelReport.Commands
{
    public class ModelReportUpsert : DbOperationAsync<ModelReportUpdateInDto, int>,INeedLog,IHaveTableName
    {
        public string TableName { get; set; } = "[Core].[ModelReport]";
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(@"EXECUTE Core.sp_ModelReportUpsert 
                                  @Id = @Id
                                 ,@ModelId = @ModelId
                                 ,@Title = @Title
                                 ,@Description = @Description
                                 ,@Layout = @Layout
                                 ,@IsLocked = @IsLocked
                                 ,@ReportId = @ReportId
                                 ,@ActionBy = @ActionBy
                                 ,@TenantId = @TenantId", new
            {
                Input.Id,
                Input.ModelId,
                Input.Title,
                Input.Description,
                Input.Layout,
                Input.IsLocked,
                Input.ReportId,
                ActionBy = Input.ModifiedBy,
                Input.TenantId,
            }).ExecuteScalarAsync<int>();
        }

    }
}
