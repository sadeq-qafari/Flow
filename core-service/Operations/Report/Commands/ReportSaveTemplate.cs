using System.Threading.Tasks;
using Core.Meteor;
using Core.Operations.Report.Dtos;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Core.Operations.Report.Commands
{
    public class ReportSaveTemplate : DbOperationAsync<ReportSaveTemplateInDto, bool>,INeedLog,IHaveTableName
    {
        public string TableName { get; set; } = "[Core].[Report]";
        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql
                    .Update("[Core].[Report]", "Template=@Template")
                    .Where("Name=@Name AND IsDeleted=0"))
                .ExecuteAsync().ValidateDatabaseAffectedRows() > 0;
        }

    }
}
