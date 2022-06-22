using Core.Operations.ModelPropertyLookup.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyLookup.Commands
{
    public class UpdateModelPropertyLookup : SaanaaDbUpdateAsync<UpdateModelPropertyLookupInDto>
    {
        public UpdateModelPropertyLookup() : base("[Core].[ModelPropertyLookup]",
            "[ModelPropertyId]=@ModelPropertyId, [Title]=@Title, [Value]=@Value")
        {
        }
    }
}
