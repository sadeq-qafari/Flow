using System.Threading.Tasks;
using Core.Meteor.Dto;
using Meteor.Database.SqlDialect;
using Meteor.Operation.Db;

namespace Core.Meteor
{
    public class DbSelectAsync<T> : DbOperationAsync<DbSelectInDto, T>, IHaveTableName
    {
        public string TableName { get; set; }

        public DbSelectAsync(string tableName)
        {
            TableName = tableName;
        }

        protected virtual ISqlDialect GetSql()
        {
            return SqlFactory!.Create()
                .Select(TableName)
                .Where("Id=@Id AND IsDeleted=0 AND (ISNULL(TenantId,0)=0 OR TenantId=@TenantId)");
        }

        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => GetSql()).QueryFirstOrDefaultAsync<T>();
        }
    }
}
