using System.Threading.Tasks;
using Meteor.Operation.Db;

namespace Core.Meteor
{
    public class DbInsertAsync<TInput> : DbOperationAsync<TInput, long>, IHaveTableName
    {
        public string TableName { get; set; }

        private readonly string _columnNames;
        private readonly string _columnValues;

        public DbInsertAsync(string tableName, string columnNames, string columnValues)
        {
            TableName = tableName;
            _columnNames = columnNames;
            _columnValues = columnValues;
        }

        protected override Task<TInput> PrepareInputAsync()
        {
            PersianText.NormalizeObject(Input);
            return Task.FromResult(Input);
        }

        protected override async Task ExecutionAsync()
        {
            Output = await NewSql(sql => sql.InsertReturnId(TableName,
                    _columnNames + ", IsActive, CreatedBy, TenantId",
                    _columnValues + ", @IsActive, @CreatedBy, @TenantId"))
                .ExecuteScalarAsync<long>();
        }
    }
}
