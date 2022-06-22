using Core.Operations.ModelPropertyElement.Dto;
using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyElement.Queries
{
    public class GetModelPropertyElementPage : SaanaaDbQueryPage<ModelPropertyElementDto>
    {
        public GetModelPropertyElementPage() : base("[Core].[ModelPropertyElement]")
        {
        }

    }
}
