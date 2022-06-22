using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyDatagrid.Queries
{
    public class GetModelPropertyDatagridByIds : SaanaaDbQueryByIds<ModelPropertyDatagrid>
    {
        public GetModelPropertyDatagridByIds() : base("[Core].[ModelPropertyDatagrid]")
        {
        }
    }
}
