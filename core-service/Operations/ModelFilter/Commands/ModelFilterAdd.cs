using Core.Meteor;
using Core.Operations.ModelFilter.Dtos;

namespace Core.Operations.ModelFilter.Commands
{
    public class ModelFilterAdd : DbInsertAsync<ModelFilterAddInDto>
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

