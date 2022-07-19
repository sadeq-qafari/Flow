using System.Threading.Tasks;
using Core.Meteor.Dto;
using Meteor.Operation.Db;

namespace Core.Meteor
{
    public class DbUpdateAsync<TInput> : DbOperationAsync<TInput, bool>, IHaveTableName where TInput : DbUpdateInDto
    {
        public string TableName { get; set; }
        private readonly string _setFields;

        public DbUpdateAsync(string tableName, string setFields)
        {
            TableName = tableName;
            _setFields = setFields;
        }

        protected override Task<TInput> PrepareInputAsync()
        {
            PersianText.NormalizeObject(Input);
            return Task.FromResult(Input);
        }

        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql.Update(TableName,
                    $"{_setFields}, IsActive=@IsActive, ModifiedBy=@ModifiedBy, ModifiedAt=getdate()")
                .Where(x => x.Where("Id=@Id AND IsDeleted=0")
                    .When(Input.HasTenant0, "(TenantId=@TenantId OR TenantId=0 OR TenantId IS NULL)")
                    .When(!Input.HasTenant0, "TenantId=@TenantId"))).ExecuteAsync() > 0;
        }
    }
}
