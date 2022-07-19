using System.Threading.Tasks;
using Core.Meteor.Dto;
using Meteor.Operation.Db;

namespace Core.Meteor
{
    public class DbDeleteAsync : DbOperationAsync<DbDeleteInDto, bool>, IHaveTableName
    {
        public string TableName { get; set; }

        public DbDeleteAsync(string tableName)
        {
            TableName = tableName;
        }

        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql.Update(TableName, "IsDeleted=1, ModifiedBy=@ModifiedBy, ModifiedAt=GETDATE()")
                    .Where(x => x.Where("Id=@Id")
                        .When(Input.HasTenant0, "(TenantId=@TenantId OR TenantId=0 OR TenantId IS NULL)")
                        .When(!Input.HasTenant0, "TenantId=@TenantId")))
                .ExecuteAsync() > 0;
        }
    }
}
