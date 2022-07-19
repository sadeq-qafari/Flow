using Core.Meteor;
using Core.Operations.ModelFilter.Dtos;

namespace Core.Operations.ModelFilter.Commands
{
    public class ModelFilterUpdate : DbUpdateAsync<ModelFilterUpdateInDto>
    {
        public ModelFilterUpdate() : base("[Core].[ModelFilter]",
            @"[Title]=@Title,
					[ModelId]=@ModelId,
					[FilterString]=@FilterString,
					[TypeLookup]=@TypeLookup")
        {
        }
    }
}