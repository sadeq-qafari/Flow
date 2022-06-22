using Saanaa.Core.Meteor;

namespace Core.Operations.Model.Queries
{
    public class GetModelByIds : SaanaaDbQueryByIds<Model>
    {
        public GetModelByIds() : base("[Core].[Model]")
        {
        }
    }
}
