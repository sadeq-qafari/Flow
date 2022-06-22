using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyDatagrid.Queries
{
    public class GetModelPropertyDatagrid : SaanaaDbSelectAsync<ModelPropertyDatagrid?>
    {
        public GetModelPropertyDatagrid() : base("[Core].[ModelPropertyDatagrid]")
        {
        }
    }
}
