using Core.Meteor;
using Core.Meteor.Dto;

namespace Tenant.Operations.Transaction
{
    public class Transaction : BaseModelDto, IDropDown
    {
        public int PersonId { get; set; }
        public string Code { get; set; }
        public decimal Amount { get; set; }
        public bool IsDeposit { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public TransactionType TypeLookup { get; set; }
        public string Description { get; set; }
    }

    public enum TransactionType
    {
        Internal = 1,
        Online,
        Transfer,
        Cash,
    }
}
