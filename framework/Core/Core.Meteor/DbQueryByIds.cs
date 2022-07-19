using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Meteor.Dto;
using Meteor.Operation.Db;

namespace Core.Meteor
{
    public class DbQueryByIds<T> : DbOperationAsync<DbQueryByIdsInDto, IEnumerable<T>>, IHaveTableName
    {
        public string TableName { get; set; }

        public DbQueryByIds(string tableName)
        {
            TableName = tableName;
        }

        protected override async Task ExecutionAsync()
        {
            var ids = !string.IsNullOrWhiteSpace(Input.Ids)
                ? Input.Ids.Split(',').Select(int.Parse).ToList()
                : new List<int>();
            Output = await NewSql(sql =>
                    sql.Select(TableName)
                        .Where("Id IN @Ids AND (TenantId=0 OR TenantId=@TenantId OR TenantId IS NULL)"),
                new {Ids = ids,TenantId = Input.TenantId}).QueryAsync<T>();
        }


    }
}
