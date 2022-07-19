using Core.Meteor;
using Tenant.Operations.Transaction.Dtos;

namespace Tenant.Operations.Transaction.Commands
{
    public class TransactionAdd : DbInsertAsync<TransactionAddInDto>
    {
        public TransactionAdd() : base("[Tenant].[Transaction]",
            @"[PersonId],
						[Code],
						[Amount],
						[IsDeposit],
						[TypeLookup],
						[Description]",
            @"@PersonId,
						@Code,
						@Amount,
						@IsDeposit,
						@TypeLookup,
						@Description")
        {
        }
    }
}

