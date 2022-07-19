using Core.Meteor;

namespace Identity.Operations.Database.ApiScope.Commands
{
    public class ApiScopeRemove : DbDeleteAsync
    {
        public ApiScopeRemove() : base("[Identity].[ApiScope]")
        {
        }
    }
}