using System.Threading.Tasks;
using Core.Meteor.Dto;
using Core.Operations.ModelReport.Dtos;
using Meteor.Operation.Db;

namespace Core.Operations.ModelReport.Queries
{
    public class GetModelReportInfo : DbOperationAsync<DbSelectInDto, ModelReportInfoDto>
    {
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql =>
                sql.Select("[Core].[ModelReport]",
                        @"ModelReport.Id
                                   ,ModelReport.ModelId
                                   ,ModelReport.Title
                                   ,ModelReport.Description
                                   ,ModelReport.Layout
                                   ,ModelReport.IsLocked
                                   ,ModelReport.ReportId
                                   ,Report.Name AS ReportName
                                   ,Model.Name AS ModelName
                                   ,Service.Name AS ServiceName
                                   ,Model.IsReport")
                    .InnerJoin("Core.Model Model", "ModelId = Model.Id")
                    .InnerJoin("Core.Service Service", "Model.ServiceId = Service.Id")
                    .LeftJoin("Core.Report Report", "ModelReport.ReportId = Report.Id")
                    .Where("ModelReport.Id=@Id")
            ).QueryFirstOrDefaultAsync<ModelReportInfoDto>();
        }
    }
}
