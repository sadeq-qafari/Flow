using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.Client.Queries
{
    public class GetClientExcel : SaanaaDbQueryExcel<Client>
    {
        public GetClientExcel() : base("[Identity].[Client]")
        {
        }
    }
}