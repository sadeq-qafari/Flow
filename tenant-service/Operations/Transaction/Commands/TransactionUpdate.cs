using Saanaa.Core.Meteor;
using Tenant.Operations.Transaction.Dtos;

namespace Tenant.Operations.Transaction.Commands
{
    public class TransactionUpdate : SaanaaDbUpdateAsync<TransactionUpdateInDto>
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
