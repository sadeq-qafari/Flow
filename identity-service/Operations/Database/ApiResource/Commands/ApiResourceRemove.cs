using Saanaa.Core.Meteor;

namespace Identity.Operations.Database.ApiResource.Commands
{
    public class ApiResourceRemove : SaanaaDbDeleteAsync
    {
        public ApiResourceRemove() : base("[Identity].[ApiResource]")
        {
        }
    }
}