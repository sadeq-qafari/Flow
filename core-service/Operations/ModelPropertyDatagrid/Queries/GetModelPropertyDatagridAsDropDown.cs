using Core.Meteor;

namespace Core.Operations.ModelPropertyDatagrid.Queries
{
    public class GetModelPropertyDatagridAsDropDown : DbQueryAsDropDown<ModelPropertyDatagrid>
    {
        public GetModelPropertyDatagridAsDropDown() : base("[Core].[ModelPropertyDatagrid]","Name")
        {
        }
    }
}
