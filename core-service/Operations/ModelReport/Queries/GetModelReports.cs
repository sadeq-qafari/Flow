using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.ModelReport.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Core.Operations.ModelReport.Queries
{
    public class GetModelReports : DbOperationAsync<ModelReportsInDto, IEnumerable<ModelReportInfoDto>>
    {
        protected override async Task ExecutionAsync()
        {
            var modelId = SqServices.GetModel(Input.ServiceName, Input.ModelName)?.Id ??
                          throw Errors.NotFound("model_not_found");
            Output = await NewSql("EXECUTE Core.sp_ModelReports @ModelId = @ModelId, @TenantId = @TenantId",
                    new { ModelId = modelId, Input.TenantId })
                .QueryAsync<ModelReportInfoDto>();
        }
    }
}
