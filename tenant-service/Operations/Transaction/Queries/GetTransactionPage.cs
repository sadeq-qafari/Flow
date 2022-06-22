using Meteor.Database.SqlDialect;
using Saanaa.Core.Meteor;
using Tenant.Operations.Transaction.Dtos;

namespace Tenant.Operations.Transaction.Queries
{
    public class GetTransactionPage : SaanaaDbQueryPage<TransactionDto>
    {
        public GetTransactionPage() : base("[Tenant].[Transaction]")
        {
        }
        


        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {
            
            return SqlFactory!.Create().Select("[Tenant].[Transaction] Transaction", isForCount ? "COUNT(*)" : @"
						Transaction.*, 
						Person.Title AS PersonTitle")
                .LeftJoin("[Tenant].[Person] Person",  "Transaction.PersonId = Person.Id  AND  Person.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[Transaction].[{fieldName}]";
    }
}