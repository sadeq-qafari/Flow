using Core.Meteor;
using Core.Operations.ModelPropertyElement.Dto;

namespace Core.Operations.ModelPropertyElement.Queries
{
    public class GetModelPropertyElementPage : DbQueryPage<ModelPropertyElementDto>
    {
        public GetModelPropertyElementPage() : base("[Core].[ModelPropertyElement]")
        {
        }

    }
}
