using Saanaa.Core.Meteor;

namespace Core.Operations.ModelPropertyDatagrid.Queries
{
    public class GetModelPropertyDatagridAsDropDown : SaanaaDbQueryAsDropDown<ModelPropertyDatagrid>
    {
        public GetModelPropertyDatagridAsDropDown() : base("[Core].[ModelPropertyDatagrid]","Name")
        {
        }
    }
}
