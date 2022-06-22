using Core.Operations.ModelFilter.Dtos;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelFilter.Commands
{
    public class ModelFilterUpdate : SaanaaDbUpdateAsync<ModelFilterUpdateInDto>
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