using Core.Operations.ModelFilter.Dtos;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelFilter.Commands
{
    public class ModelFilterAdd : SaanaaDbInsertAsync<ModelFilterAddInDto>
    {
        public ModelFilterAdd() : base("[Core].[ModelFilter]",
            @"[Title],
						[ModelId],
						[FilterString],
						[TypeLookup]",
            @"@Title,
						@ModelId,
						@FilterString,
						@TypeLookup")
        {
        }
    }
}

