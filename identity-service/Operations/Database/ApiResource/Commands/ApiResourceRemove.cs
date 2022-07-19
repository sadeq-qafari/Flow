using Core.Meteor;

namespace Identity.Operations.Database.ApiResource.Commands
{
    public class ApiResourceRemove : DbDeleteAsync
    {
        public ApiResourceRemove() : base("[Identity].[ApiResource]")
        {
        }
    }
}