using Core.Meteor;
using Tenant.Operations.Transaction.Dtos;

namespace Tenant.Operations.Transaction.Commands
{
    public class TransactionUpdate : DbUpdateAsync<TransactionUpdateInDto>
    {
        public TransactionUpdate() : base("[Tenant].[Transaction]",
            @"[PersonId]=@PersonId,
					[Code]=@Code,
					[Amount]=@Amount,
					[IsDeposit]=@IsDeposit,
                    [TypeLookup]=@TypeLookup,
					[Description]=@Description")
        {
        }
    }
}
