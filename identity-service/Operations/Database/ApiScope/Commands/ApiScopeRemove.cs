using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.ApiScope.Commands
{
    public class ApiScopeRemove : SaanaaDbDeleteAsync
    {
        public ApiScopeRemove() : base("[Identity].[ApiScope]")
        {
        }
    }
}