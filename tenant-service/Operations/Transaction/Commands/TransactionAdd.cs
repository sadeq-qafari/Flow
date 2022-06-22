using Saanaa.Core.Meteor;
using Tenant.Operations.Transaction.Dtos;

namespace Tenant.Operations.Transaction.Commands
{
    public class TransactionAdd : SaanaaDbInsertAsync<TransactionAddInDto>
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

