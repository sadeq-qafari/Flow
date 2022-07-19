using Core.Meteor;
using Core.Operations.ModelPropertyLookup.Dto;

namespace Core.Operations.ModelPropertyLookup.Commands
{
    public class UpdateModelPropertyLookup : DbUpdateAsync<UpdateModelPropertyLookupInDto>
    {
        public UpdateModelPropertyLookup() : base("[Core].[ModelPropertyLookup]",
            "[ModelPropertyId]=@ModelPropertyId, [Title]=@Title, [Value]=@Value")
        {
        }
    }
}
